using InstitutoApp.Class;
using InstitutoApp.Models.Commons;
using InstitutoApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoApp.ViewModels.Commons
{
    public class AddEditCarreraViewModel : NotificationObject
    {
		GenericService<Carrera> CarreraService = new GenericService<Carrera>();
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value;
                OnPropertyChanged();
                GuardarCommand.ChangeCanExecute();
            }
        }

        private string sigla;

        public string Sigla
        {
            get { return sigla; }
            set { sigla = value;
                OnPropertyChanged();
                GuardarCommand.ChangeCanExecute();
            }
        }
        private Carrera carrera;

		public Carrera Carrera
		{
			get { return carrera; }
			set { carrera = value;
				OnPropertyChanged();
                GuardarCommand.ChangeCanExecute();
            }
		}

		public Command GuardarCommand { get; }
        public Command CancelarCommand { get; }

        public AddEditCarreraViewModel()
        {
                GuardarCommand = new Command(Guardar, PermitirGuardar);
        }

        private bool PermitirGuardar(object arg)
        {
            return !string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(Sigla);

        }

        private async void Guardar(object obj)
        {
            var carrera = new Carrera()
            {
                Nombre = Nombre,
                Sigla = Sigla
            };
            await CarreraService.AddAsync(carrera);
        }
    }
}
