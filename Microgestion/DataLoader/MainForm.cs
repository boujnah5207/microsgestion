using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SysQ.Microgestion.Backend.Entities;
using System.Collections.ObjectModel;
using SysQ.Microgestion.Backend.Services;

namespace SysQ.Microgestion.DataLoader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.btnOpenFile.Click += (s, e) => OpenFile();
            this.btnPreview.Click += (s, e) => Preview();
            this.btnImport.Click += (s, e) => ImportData();
            this.btnExit.Click += (s, e) => this.Close();
            this.FormClosing += (s, e) =>
            {
                DialogResult result = MessageBox.Show(
                    "Esta seguro que desea salir?",
                    "Saliendo...",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                e.Cancel = (result == DialogResult.No);
            };
        }

        private void ImportData()
        {
            
        }

        private void LoadItemTypes()
        {
            this.itemTypeRecordBindingSource.Clear();

            var itemTypes = this.importDataBindingSource.Cast<ImportData>().Select(d => d.ItemTypeName).Distinct();

            foreach (var itemTypeName in itemTypes)
            {
                var itemType = ItemTypeService.GetByName(itemTypeName);

                Guid id = itemType == null ? Guid.Empty : itemType.ID;
                String name = itemType == null ? itemTypeName : itemType.Name;
                String message = itemType == null ? string.Empty : "Ya Esite. No se importará";

                this.itemTypeRecordBindingSource.Add(new ItemTypeRecord
                {
                    Id = id,
                    Name = name,
                    Import = (itemType == null),
                    ImportStatus = itemType == null ? ImportStatus.Preparado : ImportStatus.Ignorado,
                    Message = message
                });
            }

        }

        private void Preview()
        {
            LoadDataToImport();
            LoadItemTypes();
            LoadMeasurements();
        }

        private void LoadMeasurements()
        {
            this.measurementRecordBindingSource.Clear();

            var measurements = this.importDataBindingSource
                                   .Cast<ImportData>()
                                   .Select(d => new
                                   {
                                       Name = d.MeasurementName,
                                       Symbol = d.MeasurementSimbol
                                   }).Distinct();

            foreach (var m in measurements)
            {
                Measurement measurement = MeasurementService.GetByName(m.Name);

                Guid id = measurement == null ? Guid.Empty : measurement.ID;
                String name = measurement == null ? m.Name : measurement.Name;
                string symbol = measurement == null ? m.Symbol : measurement.Abbreviation;
                String message = measurement == null ? string.Empty : "Ya Esite. No se importará";

                this.measurementRecordBindingSource.Add(new MeasurementRecord
                {
                    Id = id,
                    Name = name,
                    Symbol = symbol,
                    Import = (measurement == null),
                    ImportStatus = measurement == null ? ImportStatus.Preparado : ImportStatus.Ignorado,
                    Message = message
                });
            }
        }

        private void LoadDataToImport()
        {

            this.importDataBindingSource.Clear();

            if (string.IsNullOrEmpty(this.txtFile.Text))
                return;

            if (!File.Exists(this.txtFile.Text))
                return;

            StreamReader reader = new StreamReader(this.txtFile.Text);

            // Read Header
            string headerLine = reader.ReadLine();
            string[] headers = headerLine.Split(';');

            if (headers.Length != 10)
            {
                MessageBox.Show(
                    "Se esperaban 10 columnas.",
                    "Error en el archivo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            while (!reader.EndOfStream)
            {
                string newLine = reader.ReadLine();
                string[] values = newLine.Split(';');

                Item item = ItemService.GetByName(values[0]);

                Guid id = item == null ? Guid.Empty : item.ID;
                String name = item == null ? values[0] : item.Name;
                String message = item == null ? string.Empty : "Ya Esite. No se importará";

                this.importDataBindingSource.Add(new ImportData
                {
                    Id = id,
                    ItemName = name,
                    InternalCode = values[1],
                    ExternalCode = values[2],
                    ItemTypeName = values[3],
                    MeasurementName = values[4],
                    MeasurementSimbol = values[5],
                    MovesStock = values[6],
                    MinimumStock = values[7],
                    ActualStock = values[8],
                    Price = values[9],
                    Import = (item == null),
                    ImportStatus = ImportStatus.Preparado,
                    Message = message
                });
            };
           
        }

        private void OpenFile()
        {
            var dialog = new OpenFileDialog()
            {
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "csv",
                Multiselect = false,
                Filter = "CSV (delimitado por comas)|*.csv|Todos los archivos (*.*)|*.*",
                ValidateNames = true
            };

            var result = dialog.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            this.txtFile.Text = dialog.FileName;
            return;
        }

    }

    public enum ImportStatus
    {
        Preparado,
        Importado,
        Error,
        Ignorado
    }

    public class MeasurementRecord
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public bool Import { get; set; }
        public ImportStatus ImportStatus { get; set; }
        public string Message { get; set; }
    }

    public class ItemTypeRecord
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Import { get; set; }
        public ImportStatus ImportStatus { get; set; }
        public string Message { get; set; }
    }

    public class ImportData
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public string InternalCode { get; set; }
        public string ExternalCode { get; set; }
        public string ItemTypeName { get; set; }
        public string MeasurementName { get; set; }
        public string MeasurementSimbol { get; set; }
        public string MovesStock { get; set; }
        public string MinimumStock { get; set; }
        public string ActualStock { get; set; }
        public string Price { get; set; }
        public bool Import { get; set; }
        public ImportStatus ImportStatus { get; set; }
        public string Message { get; set; }
    }
}
