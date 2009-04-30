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
using System.Transactions;
using SysQ.Microgestion.Frontend.Forms;
using SysQ.Microgestion.Frontend.Extensions;
using System.Globalization;

namespace SysQ.Microgestion.DataLoader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Measurements = new List<Measurement>();
            ItemTypes = new List<ItemType>();
            Items = new List<Item>();

            this.btnOpenFile.Click += (s, e) => OpenFile();
            this.btnPreview.Click += (s, e) => LoadFileIntoDataSources();
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

            LoginForm login = new LoginForm();
            login.ShowDialog();

            if (UserService.LoggedInUser.IsNullUser())
            {
                this.btnImport.Enabled = false;
                this.btnOpenFile.Enabled = false;
                this.btnPreview.Enabled = false;
            }
        }

        public List<Measurement> Measurements { get; set; }
        public List<ItemType> ItemTypes { get; set; }
        public List<Item> Items { get; set; }

        private void ImportData()
        {
            bool succeed = false;

            try
            {
                ImportMeasurements();
                ImportItemTypes();
                ImportItems();

                succeed = true;
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }

            if (succeed)
                MessageBox.Show(
                    "La carga de datos fue realizada con éxito.\nVerifique el resultado de cada item.",
                    "Resultado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show(
                    "La carga de datos no pudo ser realizada.\nVerifique el resultado de cada item.",
                    "Resultado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            RefreshGrids();
        }

        private void ImportItems()
        {
            using (TransactionScope scope = new TransactionScope())
            {

                List<StockDetailRecord> detail = new List<StockDetailRecord>();

                // Import Items
                Items.Clear();
                foreach (var i in importDataBindingSource.Cast<ImportData>())
                {
                    try
                    {
                        if (i.Import)
                        {
                            bool movesStock = i.MovesStock.ToLower().Trim() == "si" ? true : false;

                            Item item = new Item
                            {
                                ID = Guid.NewGuid(),
                                Name = i.ItemName,
                                ItemType = ItemTypes.Where(it => it.Name == i.ItemTypeName).Single(),
                                InternalCode = i.InternalCode,
                                ExternalCode = i.ExternalCode,
                                BaseMeasurement = Measurements.Where(m => m.Name == i.MeasurementName).Single(),
                                MinimumStock = !String.IsNullOrEmpty(i.MinimumStock) ? Double.Parse(i.MinimumStock) : 0.0,
                                MovesStock = movesStock,
                                CurrentPrice = new Price
                                {
                                    ID = Guid.NewGuid(),
                                    Date = DateTime.Now,
                                    Value = !String.IsNullOrEmpty(i.Price) ? Double.Parse(i.Price) : 0.0
                                }
                            };

                            ItemService.Save(item);

                            i.ImportStatus = ImportStatus.Importado;

                            Items.Add(item);

                            if (movesStock)
                                detail.Add(new StockDetailRecord
                                {
                                    Item = item,
                                    Amount = !String.IsNullOrEmpty(i.ActualStock) ? Double.Parse(i.ActualStock) : 0.0,
                                });

                            i.Import = false;
                        }
                        else
                            Items.Add(ItemService.GetByName(i.ItemName));
                    }
                    catch (Exception ex)
                    {
                        i.ImportStatus = ImportStatus.Error;
                        i.Message = ex.Message;
                    }
                }

                if (detail.Count > 0)
                {
                    StockMovement stockMovement = new StockMovement
                    {
                        ID = Guid.NewGuid(),
                        Comment = "Inventario de Carga Inicial de Datos",
                        Date = DateTime.Now,
                        User = UserService.LoggedInUser
                    };
                    foreach (var d in detail)
                        stockMovement.Details.Add(new StockMovementDetail
                        {
                            ID = Guid.NewGuid(),
                            Item = d.Item,
                            Amount = d.Amount,
                            StockMovement = stockMovement
                        });

                    StockMovementService.Save(stockMovement);
                }

                scope.Complete();
            }
        }

        private void ImportItemTypes()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Import ItemTypes
                ItemTypes.Clear();
                foreach (var i in itemTypeRecordBindingSource.Cast<ItemTypeRecord>())
                {
                    try
                    {
                        if (i.Import)
                        {
                            ItemType itemType = new ItemType
                            {
                                ID = Guid.NewGuid(),
                                Name = i.Name
                            };

                            ItemTypeService.Save(itemType);

                            i.ImportStatus = ImportStatus.Importado;

                            ItemTypes.Add(itemType);

                            i.Import = false;
                        }
                        else
                            ItemTypes.Add(ItemTypeService.GetByName(i.Name));
                    }
                    catch (Exception ex)
                    {
                        i.ImportStatus = ImportStatus.Error;
                        i.Message = ex.Message;
                    }
                }

                scope.Complete();
            }
        }

        private void ImportMeasurements()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                //Import Measurements
                Measurements.Clear();
                foreach (var m in measurementRecordBindingSource.Cast<MeasurementRecord>())
                {
                    try
                    {
                        if (m.Import)
                        {
                            Measurement measurement = new Measurement
                            {
                                ID = Guid.NewGuid(),
                                Name = m.Name,
                                Abbreviation = m.Symbol
                            };

                            MeasurementService.Save(measurement);

                            m.ImportStatus = ImportStatus.Importado;

                            Measurements.Add(measurement);

                            m.Import = false;
                        }
                        else
                            Measurements.Add(MeasurementService.GetByName(m.Name));

                    }
                    catch (Exception ex)
                    {
                        m.ImportStatus = ImportStatus.Error;
                        m.Message = ex.Message;
                    }
                }

                scope.Complete();
            }
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

        private void LoadFileIntoDataSources()
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
                String name = item == null ? SanitizeName(values[0]) : item.Name;
                String message = item == null ? string.Empty : "Ya Esite. No se importará";

                this.importDataBindingSource.Add(new ImportData
                {
                    Id = id,
                    ItemName = name,
                    InternalCode = values[1],
                    ExternalCode = values[2],
                    ItemTypeName = values[3].ToUpper(),
                    MeasurementName = values[4],
                    MeasurementSimbol = values[5],
                    MovesStock = values[6],
                    MinimumStock = values[7],
                    ActualStock = values[8],
                    Price = values[9],
                    Import = (item == null),
                    ImportStatus = item == null ? ImportStatus.Preparado : ImportStatus.Ignorado,
                    Message = message
                });
            };

        }

        private string SanitizeName(string name)
        {
            name = name.ToString(new CultureInfo("es-AR"));
            name = name.ToUpperInvariant();
            name = name.Replace(@"""""", @"""");
            if (name.StartsWith(@"""") && name.EndsWith(@""""))
            {
                name = name.Remove(0, 1);
                name = name.Remove(name.Length - 1, 1);
            }

            if (!name.IsNormalized())
                name.Normalize();

            // Replace bad characters
            int index = name.IndexOf((char)65533);            
            while(index != -1)
            {
                name = name.Remove(index, 1);
                index = name.IndexOf((char)65533);
            }

            return name;
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

            LoadFileIntoDataSources();
        }

        private void RefreshGrids()
        {
            this.dgvItems.Refresh();
            this.dgvItemTypes.Refresh();
            this.dgvMeasurements.Refresh();
        }
    }

    public enum ImportStatus
    {
        Preparado,
        Importado,
        Error,
        Ignorado
    }

    public class StockDetailRecord
    {
        public Item Item { get; set; }
        public double Amount { get; set; }
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
