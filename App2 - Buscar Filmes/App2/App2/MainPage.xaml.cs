using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App2.Services;
using App2.Services.Models;

namespace App2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarFilme;
        }

        private void BuscarFilme(object sender, EventArgs args)
        {
            string filme = FILME.Text.Trim();

                try
                {
                    Movies end = Search.BuscarEndereco(filme);

                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Titulo: {0} \n" +
                                                          "Ano: {1} \n" +
                                                          "Released: {2} \n" +
                                                          "Plot: {3} \n" +
                                                          "Genre: {4} \n" +
                                                          "Director: {5} \n" +
                                                          "Writer: {6} \n" +
                                                          "Actors: {7} \n" +
                                                          "Language: {8} \n" +
                                                          "Country: {9} \n" +
                                                          "IMDB Rating: {10} \n"
                                                         , end.Title, 
                                                           end.Year, 
                                                           end.Released, 
                                                           end.Plot,
                                                           end.Genre,
                                                           end.Director,
                                                           end.Writer,
                                                           end.Actors,
                                                           end.Language,
                                                           end.Country,
                                                           end.imdbRating);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O filme não foi encontrado: " + filme, "OK");
                    }
                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }            
        }
    }
}
