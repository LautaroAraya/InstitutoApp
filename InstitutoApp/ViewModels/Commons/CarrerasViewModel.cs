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


		public CarrerasViewModel()
        {
			carreras = new ObservableCollection<Carrera>();
			ObtenerCarreras();
        }

        private async void ObtenerCarreras()
        {
			ActivityStart = true;
            var carreras=await carreraService.GetAllAsync();
			foreach (var carrera in carreras)
			{
				Carreras.Add(carrera);
			}
			ActivityStart = false;

        }
    }
}
