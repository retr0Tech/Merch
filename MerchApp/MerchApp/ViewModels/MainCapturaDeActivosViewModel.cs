using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MerchApp.ViewModels
{
    public class MainCapturaDeActivosViewModel : TriggerAction<Entry>, INotifyPropertyChanged
    {
        #region Class Properties
        /*
         * Empresa 0
         * Edificio 1
         * Piso 2
         * Centro de Costo 3
         * Oficina 4
         * Description 5
         * Marca/Modelo 6
         * Empleado 7
         */
        int ListaActual = 0;
        List<string> data { get; set; }
        private ObservableCollection<string> Descripcion_;
        //MainCapturaDeActivosViewModel c = new MainCapturaDeActivosViewModel();
        private long selectedIndex;

        #endregion

        #region Static Properties

        public static string _Empresa;
        public static string _Edificio;
        public static string _Piso;
        public static string _CentroCosto;
        public static string _Oficina;
        public static string _Descripcion;
        public static string _Empleado;

        #endregion

        #region Propiedades Parametros

        public ICommand BtnUbicacion { get; set; }
        public string Busqueda { get; set; }
        public ObservableCollection<string> ListaDescripcion { get; set; }
        public ObservableCollection<string> Descripcion
        {
            get
            {
                return Descripcion_;
            }
            set
            {
                Descripcion_ = value;
                NotifyPropertyChanged("Descripcion");
            }
        }
        public string ListaDe { get; set; }
        public long SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
                NotifyPropertyChanged("SelectedIndex");
            }
        }
        string sel;
        public string Selectoption
        {
            get { return sel; }
            set
            {
                if (sel != value)
                {
                    _Empresa = sel;
                }
            }
        }
        public ICommand enter { get; set; }

        #endregion

        #region Propiedades Entrada

        public string LinkCentroCosto { get; set; }
        public string LinkOficina { get; set; }
        public string Tag { get; set; }
        public string LinkDescripcion { get; set; }
        public string LinkMarcaModelo { get; set; }
        public string Tag1 { get; set; }

        #endregion

        #region Propiedades Consulta

        public string TagParaAsignar { get; set; }
        public string Empresa { get; set; }
        public string Piso { get; set; }
        public string CentroCosto { get; set; }
        public string Oficina { get; set; }
        public string DescripcionActivo { get; set; }
        public string Serial { get; set; }
        public string Empleado { get; set; }

        #endregion

        #region Propiedades Anterior

        public ICommand PrimerActivo { get; set; }
        public ICommand ActivoAnterior { get; set; }
        public ICommand ActivoSiguiente { get; set; }
        public ICommand UltimoActivo { get; set; }
        public string OficinaAnterior { get; set; }
        public string DescripcionAnterior { get; set; }
        public string TAG { get; set; }

        #endregion

        public MainCapturaDeActivosViewModel()
        {
            //c = this;
            #region Metodos Parametros

            ListaDescripcion = new ObservableCollection<string>();
            Descripcion = new ObservableCollection<string>();
            ListaDescripcion.Add("Empresa");
            ListaDescripcion.Add("Edificio");
            ListaDescripcion.Add("Piso");
            ListaDescripcion.Add("Centro de Costo");
            ListaDescripcion.Add("Oficina");
            ListaDescripcion.Add("Descripción");
            ListaDescripcion.Add("Marca/Modelo");
            ListaDescripcion.Add("Empleado");

            Descripcion.Add("Prueba 1");
            Descripcion.Add("Test 1");
            data = Descripcion.ToList();
            BtnUbicacion = new Command(async () =>
            {
                ListaDe = ListaDescripcion.First();
                Descripcion.Add("nuevo");
                //await App.Current.MainPage.Navigation.PushAsync(new DondeEstoyPage());
            });
            ListaDe = ListaDescripcion.First();
            //Selectoption = new Command(async () =>
            //{
            //    var response = await App.Current.MainPage.DisplayActionSheet("Actions", "cancel", "", $"Call", "Edit");
            //    if (response == "Edit")
            //    {

            //    }
            //    else if (response.StartsWith("Call", StringComparison.Ordinal))
            //    {
            //        Device.OpenUri(new Uri(String.Format($"tel:{"0"}")));
            //    }
            //});
            enter = new Command(async () =>
            {
                var dataEmpty = data.Where(i => i.ToLower().Contains(Busqueda.ToLower()));
                Descripcion.Clear();
                foreach (var element in dataEmpty)
                {
                    Descripcion.Add(element);
                }
            });

            #endregion

            #region Metodos Entrada

            LinkCentroCosto = "Seleccionar Centro de Costos";
            LinkOficina = "Seleccionar Oficina";
            LinkDescripcion = "Seleccionar Descripcion";
            LinkMarcaModelo = "Seleccionar Marca | Modelo";

            #endregion

            #region Metodos Consuta
            #endregion

            #region Metodos Anterior

            PrimerActivo = new Command(async () =>
            {

            });

            ActivoAnterior = new Command(async () =>
            {

            });
            ActivoSiguiente = new Command(async () =>
            {

            });

            UltimoActivo = new Command(async () =>
            {

            });

            #endregion

        }
        public MainCapturaDeActivosViewModel Reset()
        {
            return new MainCapturaDeActivosViewModel();
        }
        protected async override void Invoke(Entry entry)
        {
            Descripcion.Add("tito");
            try
            {
                var dataEmpty = data.Where(i => i.ToLower().Contains(entry.Text.ToLower()));
                //c.Reset();

            }
            catch (Exception ex)
            {



            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}