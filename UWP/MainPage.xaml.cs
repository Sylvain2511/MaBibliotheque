using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ModelObjet;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        EntityModel model;


        List<string> lesGenres;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            model = new EntityModel();
            lvDocuments.ItemsSource = null;

            lesGenres = new List<string>();
            lesGenres.Add("Tous"); lesGenres.Add("Film"); lesGenres.Add("Livre");
            cboGenre.ItemsSource = lesGenres;
        }

        private void cboGenre_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string cbo = cboGenre.SelectedItem.ToString();
            if (cboGenre.SelectedItem != null)
            {
                if (cboGenre.SelectedItem.ToString() == "Tous")
                {
                    lvDocuments.ItemsSource = null;
                    var query = from d in model.LesDocuments
                                select new Document { Titre = d.Titre, Etat = d.Etat };
                    lvDocuments.ItemsSource = query.ToList();

                }
                if (cboGenre.SelectedItem.ToString() == "Film")
                {
                    lvDocuments.ItemsSource = null;
                    var query = from f in model.LesFilms
                                select new Film { Photo = f.Photo, Titre = f.Titre, Etat = f.Etat };
                    lvDocuments.ItemsSource = query.ToList();

                }
                if (cboGenre.SelectedItem.ToString() == "Livre")
                {
                    lvDocuments.ItemsSource = null;
                    var query = from l in model.LesLivres
                                select new Livre { Photo = l.Photo, Titre = l.Titre, Etat = l.Etat };
                    lvDocuments.ItemsSource = query.ToList();
                }
            }
        }
        private void lvDocuments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (lvDocuments.SelectedItem != null)
            {
                gvActeurs.ItemsSource = null;
                
                var query1 = from p in model.LesParticipants
                             where p.NumFilm == (lvDocuments.SelectedItem as Participer).NumFilm
                             select p.NumActeur;
                var query = from f in model.LesFilms
                            join p in model.LesParticipants on f.IdFilm equals p.NumFilm
                            join a in model.LesActeurs on p.NumActeur equals a.IdActeur
                            where a.IdActeur == Convert.ToUInt32(query1)
                            select new Acteur { PhotoActeur = a.PhotoActeur, NomActeur = a.NomActeur };
                            
                if (lvDocuments.SelectedItem is Film)
                {
                    /*var query = from a in model.LesActeurs
                                join p in model.LesParticipants on a.IdActeur equals p.NumActeur
                                where a.IdActeur == Convert.ToInt32(from p in model.LesParticipants
                                                                    where p.NumFilm == (lvDocuments.SelectedItem as Participer).NumFilm
                                                                    select p.NumActeur)
                                select new Acteur { PhotoActeur = a.PhotoActeur, NomActeur = a.NomActeur };
                                */
                    gvActeurs.ItemsSource = query.ToList();
                }
            }
        }        
    }
}
