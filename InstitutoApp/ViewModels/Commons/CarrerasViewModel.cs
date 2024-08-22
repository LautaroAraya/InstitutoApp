using InstitutoApp.Class;
using InstitutoApp.Models.Commons;
using InstitutoApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoApp.ViewModels.Commons
{
    public class CarrerasViewModel : NotificationObject
    {
		GenericService<Carrera> carreraService=new GenericService<Carrera>();

		private bool activityStart;
		public bool ActivityStart
		{
			get { return activityStart; }
			set { activityStart = value;
				OnPropertyChanged();
			}
		}

		private ObservableCollection<Carrera> carreras;
		public ObservableCollection<Carrera> Carreras
		{
			get { return carreras; }
			set { carreras = value;
				OnPropertyChanged();
			}
		}

		private Carrera carreraCurrent;

		public Carrera CarreraCurrent
		{
			get { return carreraCurrent; }
			set { carreraCurrent = value;
				OnPropertyChanged();
				EditarCommand.ChangeCanExecute();
				EliminarCommand.ChangeCanExecute();
			}
		}


		public Command AgregarCommand { get;}
		public Command EditarCommand { get; }
		public Command EliminarCommand { get; }


		public CarrerasViewModel()
        {
			carreras = new ObservableCollection<Carrera>();
			ObtenerCarreras();
			AgregarCommand = new Command(Agregar);
            EditarCommand = new Command(Editar, PermitirEditar);
			EliminarCommand = new Command(Eliminar, PermitirElimiar);
        }

        private bool PermitirElimiar(object arg)
        {
			return carreraCurrent!=null;
        }

        private async void Eliminar(object obj)
        {
			bool respuesta = await Application.Current.MainPage.DisplayAlert("Eliminar una carrera", $"Estas seguro que desea eliminar la carrera{carreraCurrent.Nombre}", "Si", "No");
			if (respuesta) 
			{
				activityStart = true;
				await carreraService.DeleteAsync(carreraCurrent.Id);
				ObtenerCarreras();
			}
        }

        private bool PermitirEditar(object arg)
        {
            return carreraCurrent != null;
        }

        private void Editar(object obj)
        {
            throw new NotImplementedException();
        }

        private void Agregar(object obj)
        {
            throw new NotImplementedException();
        }

        private async void ObtenerCarreras()
        {
			ActivityStart = true;
            var carreras=await carreraService.GetAllAsync();
			Carreras.Clear();
			foreach (var carrera in carreras)
			{
				Carreras.Add(carrera);
			}
			ActivityStart = false;

        }
    }
}
