using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using Blackspot.Microgestion.Frontend.Forms;
using Blackspot.Microgestion.Backend.Entities;
using Blackspot.Microgestion.Backend.Services;
using Blackspot.Microgestion.Backend.Extensions;
using Blackspot.Microgestion.Backend.Enumerations;
using Blackspot.Microgestion.Frontend.Extensions;

namespace Blackspot.Microgestion.Frontend.Controllers
{
    internal class MeasurementsFormController : ControllerBase<MeasurementsForm>
    {

        public MeasurementsFormController(MeasurementsForm form)
            : base(form) { }

        internal BindingList<Measurement> Measurements { get; set; }

        internal override void InitializeForm()
        {
            try
            {
                Measurements = new BindingList<Measurement>(MeasurementService.GetAll());

                base.InitializeForm();
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        public bool AllowAdd { get { return UserService.CanPerform(SystemAction.MeasurementAdd); } set { } }
        public bool AllowDelete { get { return UserService.CanPerform(SystemAction.MeasurementDelete); } set { } }
        public bool AllowEdit
        {
            get
            {
                return (UserService.CanPerform(SystemAction.MeasurementEdit) ||
                        UserService.CanPerform(SystemAction.MeasurementAdd));
            }
            set { }
        }

        internal void AddNew()
        {
            try
            {
                Measurement newMeasurement = new Measurement();

                MeasurementEditor editor = new MeasurementEditor(newMeasurement);

                var result = editor.ShowDialog();
                if (result == DialogResult.Cancel)
                    return;

                MeasurementService.Save(newMeasurement);
                Measurements.Add(newMeasurement);
                Form.Grid.CurrentCell = Form.Grid.Rows[Form.Grid.Rows.Count - 1].Cells[1];
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        internal void Delete()
        {
            try
            {
                if (Form.Grid.SelectedRows.Count != 1)
                    return;

                if (UserAccepts(
                    "¿Desea eliminar la unidad seleccionada?",
                    "Eliminar Unidad de Medida"))
                {
                    Measurement measurement = Form.Grid.SelectedRows[0].DataBoundItem as Measurement;
                    MeasurementService.Delete(measurement);
                    Measurements.Remove(measurement);
                }
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        internal void Edit()
        {
            try
            {
                if (Form.Grid.SelectedRows.Count != 1)
                    return;

                Measurement measurement = Form.Grid.SelectedRows[0].DataBoundItem as Measurement;

                string measurementName = measurement.Name;
                string measurementAbbreviation = measurement.Abbreviation;

                MeasurementEditor editor = new MeasurementEditor(measurement);

                var result = editor.ShowDialog(Form);
                if (result == DialogResult.Cancel)
                {
                    measurement.Name = measurementName;
                    measurement.Abbreviation = measurementAbbreviation;
                }
                else
                {
                    MeasurementService.Update(measurement);
                }
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

    }
}
