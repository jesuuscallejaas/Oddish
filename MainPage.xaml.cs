using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace ProyectoUWPEnBlanco
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (miPokemon != null)
            {
                miPokemon.verFondo(true);
                miPokemon.verFilaVida(true);
                miPokemon.verFilaEnergia(true);
                miPokemon.verPocionVida(true);
                miPokemon.verPocionEnergia(true);
                miPokemon.verNombre(true);
                miPokemon.activarAniIdle(true);
            }
        }

        private void cambiarVida(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (miPokemon != null)
                miPokemon.Vida = e.NewValue;
        }

        private void cambiarEnergía(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (miPokemon != null)
                miPokemon.Energia = e.NewValue;
        }

        private void EjecutarAtaqueFuerte(object sender, RoutedEventArgs e)
        {
            miPokemon?.animacionAtaqueFuerte();
        }

        private void EjecutarAtaqueFlojo(object sender, RoutedEventArgs e)
        {
            miPokemon?.animacionAtaqueFlojo();
        }

        private void EjecutarDefensa(object sender, RoutedEventArgs e)
        {
            miPokemon?.animacionDefensa();
        }

        private void EjecutarDescansar(object sender, RoutedEventArgs e)
        {
            miPokemon?.animacionDescasar();
        }

        private void activarIddle(object sender, RoutedEventArgs e)
        {
            miPokemon?.activarAniIdle(true);
        }

        private void desactivarIddle(object sender, RoutedEventArgs e)
        {
            miPokemon?.activarAniIdle(false);
        }

        private void activarCansado(object sender, RoutedEventArgs e)
        {
            miPokemon?.animacionCansado();
        }

        private void desactivarCansado(object sender, RoutedEventArgs e)
        {
            miPokemon?.animacionNoCansado();
        }

        private void activarHerido(object sender, RoutedEventArgs e)
        {
            miPokemon?.animacionHerido();
        }

        private void desactivarHerido(object sender, RoutedEventArgs e)
        {
            miPokemon?.animacionNoHerido();
        }

        private void activarEscudo(object sender, RoutedEventArgs e)
        {
            miPokemon?.verEscudo();
        }

        private void desactivarEscudo(object sender, RoutedEventArgs e)
        {
            miPokemon?.verEscudo(false);
        }

        private void verFondo(object sender, RoutedEventArgs e)
        {
            miPokemon?.verFondo(true);
        }

        private void noVerFondo(object sender, RoutedEventArgs e)
        {
            miPokemon?.verFondo(false);
        }

        private void verFilaVida(object sender, RoutedEventArgs e)
        {
            miPokemon?.verFilaVida(true);
        }

        private void noVerFilaVida(object sender, RoutedEventArgs e)
        {
            miPokemon?.verFilaVida(false);
        }

        private void verFilaEnergia(object sender, RoutedEventArgs e)
        {
            miPokemon?.verFilaEnergia(true);
        }

        private void noVerFilaEnergía(object sender, RoutedEventArgs e)
        {
            miPokemon?.verFilaEnergia(false);
        }

        private void verPocimaVida(object sender, RoutedEventArgs e)
        {
            miPokemon?.verPocionVida(true);
        }

        private void noVerPocimaVida(object sender, RoutedEventArgs e)
        {
            miPokemon?.verPocionVida(false);
        }

        private void verPocimaEnergia(object sender, RoutedEventArgs e)
        {
            miPokemon?.verPocionEnergia(true);
        }

        private void noVerPocimaEnergia(object sender, RoutedEventArgs e)
        {
            miPokemon?.verPocionEnergia(false);
        }

        private void verNombrePokemon(object sender, RoutedEventArgs e)
        {
            miPokemon?.verNombre(true);
        }

        private void noVerNombrePokemon(object sender, RoutedEventArgs e)
        {
            miPokemon?.verNombre(false);
        }
    }
}
