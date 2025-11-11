using System;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.Media.Playback;

namespace ProyectoUWPEnBlanco
{
    public sealed partial class OddishJCS : UserControl, iPokemon
    {
        DispatcherTimer dtTime;
        private bool estaHerido = false;
        private bool estaCansado = false;
        private bool estaDerrotado = false;
        private bool descansoPorTecla = false;
        private MediaPlayer mpSonidos = new MediaPlayer();

        public OddishJCS()
        {
            this.InitializeComponent();
            this.Loaded += Page_Loaded;
            this.KeyDown += ControlTeclas;
            this.IsTabStop = true;

            // Configuración inicial de propiedades
            Nombre = "Oddish";
            Vida = 100;
            Energia = 50;
            Categoría = "Hierba";
            Tipo = "Planta/Veneno";
            Altura = 0.5;
            Peso = 5.4;
            Evolucion = "Gloom";
            Descripcion = "Pokémon tipo planta que se mueve bajo la luz de la luna.";
        }

        #region Implementación de iPokemon (Propiedades)
        public double Vida
        {
            get => pbHealth.Value;
            set => pbHealth.Value = value;
        }

        public double Energia
        {
            get => pbEnergy.Value;
            set => pbEnergy.Value = value;
        }

        public string Nombre
        {
            get => pokemonNombre.Text;
            set => pokemonNombre.Text = value;
        }

        public string Categoría { get; set; }
        public string Tipo { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public string Evolucion { get; set; }
        public string Descripcion { get; set; }
        #endregion

        #region Implementación de iPokemon (Métodos de visualización)
        public void verFondo(bool ver)
        {
            imFondo.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verFilaVida(bool ver)
        {
            pbHealth.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verFilaEnergia(bool ver)
        {
            pbEnergy.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verPocionVida(bool ver)
        {
            imgPotionRed.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verPocionEnergia(bool ver)
        {
            imgPotionYellow.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verNombre(bool ver)
        {
            pokemonNombre.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verEscudo(bool ver)
        {
            // Implementar lógica para mostrar/ocultar escudo visual
        }
        #endregion

        #region Implementación de iPokemon (Animaciones)
        public void activarAniIdle(bool activar)
        {
            var sb = this.Resources["IdleAnimation"] as Storyboard;
            if (sb != null)
            {
                if (activar) sb.Begin();
                else sb.Stop();
            }
        }

        public void animacionAtaqueFlojo()
        {
            var sb = this.Resources["AtaqueFlojoStoryboard"] as Storyboard;
            if (sb != null)
            {
                sb.Begin();
            }
        }


        public void animacionDerrotado()
        {
            var sb = this.Resources["DerrotadoStoryboard"] as Storyboard;
            if (sb != null)
            {
                sb.Begin();
            }
        }


        public void animacionAtaqueFuerte()
        {
            var storyboard = this.Resources["AtaqueFuerteStoryboard"] as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }


        public void animacionDefensa()
        {
            var sb = this.Resources["DefensaStoryboard"] as Storyboard;
            if (sb != null)
            {
                sb.Begin();
            }
        }
        public void animacionDescasar()
        {
            var storyboard = this.Resources["DescansoStoryboard"] as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        public void animacionCansado()
        {
            var storyboard = this.Resources["CansadoStoryboard"] as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        } 


        public void animacionNoCansado()
        {
        }


        public void animacionHerido()
        {
            var storyboard = this.Resources["HeridoSeveroStoryboard2"] as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }
        public void animacionNoHerido()
        {
        }
        public void verEscudo()
        {
            var sb = (Storyboard)this.Resources["EscudoStoryboard"];
            sb?.Begin();
        }

        public void animacionDerrota()
        {
        }
        #endregion

        #region Métodos de Interacción
        private void UsePotionRed(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += IncreaseHealth;
            dtTime.Start();
            imgPotionRed.Visibility = Visibility.Collapsed;
            IniciarAnimacionDescanso(false);
        }

        private void UsePotionYellow(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += IncreaseEnergy;
            dtTime.Start();
            imgPotionYellow.Visibility = Visibility.Collapsed;
            IniciarAnimacionDescanso(false);
        }
        #endregion

        #region Lógica de Estado
        private void IncreaseHealth(object sender, object e)
        {
            if (pbHealth.Value < 100)
            {
                pbHealth.Value += 2;
            }

            if (pbHealth.Value >= 100)
            {
                pbHealth.Value = 100;
                DetenerTimer();
                DetenerAnimacionDescanso();
            }

            estaHerido = false;
            estaCansado = false;
        }

        private void IncreaseEnergy(object sender, object e)
        {
            if (pbEnergy.Value < 100)
            {
                pbEnergy.Value += 2;
            }

            if (pbEnergy.Value >= 100)
            {
                pbEnergy.Value = 100;
                DetenerTimer();
                DetenerAnimacionDescanso();
            }

            estaHerido = false;
            estaCansado = false;
        }

        private void DetenerTimer()
        {
            if (dtTime != null)
            {
                dtTime.Stop();
                dtTime = null;
            }
        }
        #endregion

        #region Animaciones y Sonidos
        private void IniciarAnimacionDescanso(bool activadoPorTecla)
        {
        }

        private async void ActivarRecuperarDescanso()
        {
        }

        public async void DetenerAnimacionDescanso()
        {
        }

        public async void AnimarHerido()
        {
        }

        public async void AnimarDerrotado()
        {
        }

        #endregion

        #region Eventos y Control
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            activarAniIdle(true);
        }

        private void ControlTeclas(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case Windows.System.VirtualKey.Number1:
                    animacionAtaqueFlojo();
                    break;
                case Windows.System.VirtualKey.Number2:
                    animacionAtaqueFuerte();
                    break;
                case Windows.System.VirtualKey.Number3:
                    animacionDefensa();
                    break;
                case Windows.System.VirtualKey.Number4:
                    animacionDescasar();
                    break;
                case Windows.System.VirtualKey.Number5:
                    animacionHerido();
                    break;
                case Windows.System.VirtualKey.Number6:
                    animacionCansado();
                    break;
                case Windows.System.VirtualKey.Number7:
                    animacionDerrota();
                    break;
            }
        }

        private void pbHealth_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (pbHealth.Value == 0)
            {
                if (!estaDerrotado)
                {
                    estaDerrotado = true;
                }
                return;
            }

            if (estaDerrotado && pbHealth.Value > 0)
            {
                estaDerrotado = false;
                ResetearEstado();
                return;
            }

            if (pbHealth.Value <= 30)
            {
                if (!estaHerido)
                {
                    estaHerido = true;
                }
            }
            else if (pbHealth.Value > 30 && estaHerido)
            {
                estaHerido = false;
            }
        }

        private void pbEnergy_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (pbEnergy.Value >= 100)
            {
                pbEnergy.Value = 100;
                ResetearEstado();
            }

            if (pbEnergy.Value <= 30)
            {
                if (!estaCansado)
                {
                    estaCansado = true;
                }
            }
            else if (pbEnergy.Value > 30 && estaCansado)
            {
                estaCansado = false;
            }
        }

        public void ResetearEstado()
        {
            if (estaDerrotado) return;

            var sbIdle = this.Resources["IdleAnimation"] as Storyboard;
            sbIdle?.Begin();

            estaHerido = false;
            estaCansado = false;
            DetenerTimer();
            this.Focus(FocusState.Programmatic);
        }
        #endregion
    }
}