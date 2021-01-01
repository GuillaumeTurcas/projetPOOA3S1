using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace GestionClubTenis
{
    public partial class MainWindow : Window
    {
        #region elements début

        /// <summary>
        /// Variables accessible de partout
        /// </summary>

        StreamReader lire = null;
        string nom = "";
        string niveau;
        string fichierCompet = "Competition.txt";
        string prenom = "";
        string birthday = "";
        string sexe = "";
        string ligne = "";
        string fichierAnnuaire = "Membre.txt";
        string fichierAnnuaireSalar = "Salarie.txt";
        char[] separateurs = { ' ', ',', ';' };
        bool salarie = false;
        bool smembre;
        bool cotisation;
        string titre;
        string adresse;
        string ville;
        double salaire;
        string fichierEquipe = "Equipe.txt";
        string coordbancaire;
        string datEntre;

        #endregion

        #region Principal

        public MainWindow()
        {
            InitializeComponent();
            ToutHide();
            Initialisation();
            MenuPrincipal.Visibility = Visibility.Visible;
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            ToutHide();
            MenuPrincipal.Visibility = Visibility.Visible;
        }

        #endregion

        #region Initialisation Sauvegarde 

        public void Initialisation() //lit les .txt et les mets dans des listes
        {
            lire = new StreamReader(fichierAnnuaire);
            string[] membre;
            while (lire.Peek() > 0)
            {
                ligne = lire.ReadLine();
                membre = ligne.Split(separateurs);
                if (membre.Length == 10)
                {
                    Membre newMembre = new Membre(membre[0], membre[1], membre[2], membre[3], membre[4], membre[5], membre[6], membre[7], Convert.ToBoolean(membre[8]), Convert.ToBoolean(membre[9]));
                    ListStatic.lMembre.Add(newMembre);
                }
            }
            lire.Close();

            lire = new StreamReader(fichierAnnuaireSalar);
            string[] salare;
            while (lire.Peek() > 0)
            {
                ligne = lire.ReadLine();
                salare = ligne.Split(separateurs);
                if (salare.Length == 10)
                {
                    Salarie newSalar = new Salarie(salare[0], salare[1], salare[2], salare[3], salare[4], salare[5], salare[6], Convert.ToDouble(salare[7]), salare[8], salare[9]);
                    ListStatic.lSalarie.Add(newSalar);
                }

            }
            lire.Close();

            lire = new StreamReader(fichierEquipe);
            while (lire.Peek() > 0)
            {
                ligne = lire.ReadLine();
                membre = ligne.Split(separateurs);
                if (membre.Length == 15)
                {
                    Equipe newEquipe = new Equipe(membre[0], membre[1], membre[2], membre[3], membre[4], membre[5], 
                        membre[6], membre[7], membre[8], Convert.ToBoolean(membre[9]), Convert.ToBoolean(membre[10]), 
                        Convert.ToInt32(membre[11]), Convert.ToInt32(membre[12]), Convert.ToInt32(membre[13]), Convert.ToInt32(membre[14]));
                    ListStatic.lEquipe.Add(newEquipe);
                }

            }
            lire.Close();

            lire = new StreamReader(fichierCompet);
            while (lire.Peek() > 0)
            {
                ligne = lire.ReadLine();
                membre = ligne.Split(separateurs);
                if (membre.Length == 6)
                {
                    Competition newCompet = new Competition(membre[0], membre[1], Convert.ToInt32(membre[2]), Convert.ToInt32(membre[3]), membre[4], Convert.ToBoolean(membre[5]));
                    ListStatic.lCompet.Add(newCompet);
                }

            }
            lire.Close();

            //Pour le module autre
            List<Membre> Lm = ListStatic.lMembre.FindAll(delegate (Membre m)
            { return m.Age() < 18; });
            foreach (Membre m in Lm)
            {
                Junior J = new Junior(m.Nom, m.Prenom);
                ListStatic.lJunior.Add(J);
            }
        }


        public void Sauvegarde() //remet dans un .txt vide (afin d'évier les doublons) les elements des listes grave aux .afficher() qui retournent des strings
        {
            File.Delete(fichierAnnuaire);
            FileStream sw = File.Open(fichierAnnuaire, FileMode.CreateNew);
            sw.Close();

            File.Delete(fichierAnnuaireSalar);
            sw = File.Open(fichierAnnuaireSalar, FileMode.CreateNew);
            sw.Close();

            File.Delete(fichierEquipe);
            sw = File.Open(fichierEquipe, FileMode.CreateNew);
            sw.Close();

            File.Delete(fichierCompet);
            sw = File.Open(fichierCompet, FileMode.CreateNew);
            sw.Close();

            StreamWriter ecrire = new StreamWriter(fichierAnnuaire);
            for (int i = 0; i < ListStatic.lMembre.Count; i++)
            {
                ecrire.WriteLine(ListStatic.lMembre[i].Afficher());
            }
            ecrire.Close();

            ecrire = new StreamWriter(fichierAnnuaireSalar);
            for (int i = 0; i < ListStatic.lSalarie.Count; i++)
            {
                ecrire.WriteLine(ListStatic.lSalarie[i].Afficher());
            }
            ecrire.Close();

            ecrire = new StreamWriter(fichierEquipe);
            for (int i = 0; i < ListStatic.lEquipe.Count; i++)
            {
                ecrire.WriteLine(ListStatic.lEquipe[i].Afficher());
            }
            ecrire.Close();

            ecrire = new StreamWriter(fichierEquipe);
            for (int i = 0; i < ListStatic.lEquipe.Count; i++)
            {
                ecrire.WriteLine(ListStatic.lEquipe[i].Afficher());
            }
            ecrire.Close();

            ecrire = new StreamWriter(fichierCompet);
            for (int i = 0; i < ListStatic.lCompet.Count; i++)
            {
                ecrire.WriteLine(ListStatic.lCompet[i].Afficher());
            }
            ecrire.Close();
        }

        #endregion 

        #region Membre

        #region début

        private void ModuleMembre(object sender, RoutedEventArgs e) //affiche les grids
        {
            ToutHide();
            Module_Membre.Visibility = Visibility.Visible;
            TextePrincipalMembre.Visibility = Visibility.Visible;
        }

        private void Precedent_Click(object sender, RoutedEventArgs e) //affiche les grids
        {
            ToutHide();
            Sauvegarde();
            Module_Membre.Visibility = Visibility.Visible;
            TextePrincipalMembre.Visibility = Visibility.Visible;
        }

       
        #endregion

        #region Entrer Nouveau Membre


        public void EntrerNvMbre(object sender, RoutedEventArgs e) //mets les elements renres dans un nouveau membre
        {
            ToutHide();
            this.nom = nombox.Text;
            this.prenom = prenombox.Text;
            this.adresse = adressebox.Text;
            this.ville = Villebox.Text;
            string numeroTel = numerobox.Text;
            this.birthday = jour.Text + "/" + moisbox.Text + "/" + annee.Text;

            if (this.salarie == false) // si ce nest pas un salarie
            {
                Membre newMembre = new Membre(nom, prenom, birthday, this.sexe, this.adresse, this.ville, numeroTel, titre, cotisation, false);
                ListStatic.lMembre.Add(newMembre);
                if(newMembre.Age() < 18) { Junior J = new Junior(newMembre.Nom, newMembre.Prenom); ListStatic.lJunior.Add(J); } //test si cest un junior, si oui le rajoute dans la liste
            }

            if (salarie == true)
            {
                this.coordbancaire = postbox.Text;
                this.salaire = Convert.ToDouble(salairbox.Text);
                this.datEntre = DateTime.Now.ToString("dd/MM/yyyy");
                if (smembre == true) //si cest un salarie mais cest un membre en meme temps, alors cree deux fois lun dans la liste salarie lun dans la liste membre
                {
                    Membre newMembre = new Membre(nom, prenom, birthday, this.sexe, this.adresse, this.ville, numeroTel, titre, cotisation, false);
                    ListStatic.lMembre.Add(newMembre);
                    smembre = false;
                }
                Salarie newSalar = new Salarie(this.nom, this.prenom, this.birthday, this.sexe, this.adresse, this.ville, numeroTel, this.salaire, this.coordbancaire, this.datEntre);
                ListStatic.lSalarie.Add(newSalar);
            }
            Sauvegarde();

            Module_Membre.Visibility = Visibility.Visible;
            TextePrincipalMembre.Visibility = Visibility.Visible; 
            nombox.Text = "Nom";
            prenombox.Text = "Prénom";
            adressebox.Text = "Adresse (_ pour les espaces)";
            Villebox.Text = "Ville";
            numerobox.Text = "Numéro de téléphone";
            jour.Text = "Jour (XX)";
            moisbox.Text = "Mois (XX)";
            annee.Text = "Années (XXXX)";
            postbox.Text = "Coordonnées bancaires";
            salairbox.Text = "Salaire";

        }

        #region Boutons NvxMembres

        private void Homme_Click(object sender, RoutedEventArgs e)
        {
            Femme.Visibility = Visibility.Hidden;
            Enfant.Visibility = Visibility.Hidden;
            this.sexe = "Homme";
        }

        private void Enfant_Click(object sender, RoutedEventArgs e)
        {
            Femme.Visibility = Visibility.Hidden;
            Homme.Visibility = Visibility.Hidden;
            this.sexe = "Enfant";
        }

        private void Femme_Click(object sender, RoutedEventArgs e)
        {
            Enfant.Visibility = Visibility.Hidden;
            Homme.Visibility = Visibility.Hidden;
            this.sexe = "Femme";
        }

        private void Salarie_Click(object sender, RoutedEventArgs e)
        {
            ToutHide();
            this.salarie = true;


            competbox.Visibility = Visibility.Visible;
            loisirbox.Visibility = Visibility.Visible;

            nonpayee.Visibility = Visibility.Visible;
            payee.Visibility = Visibility.Visible;

            Femme.Visibility = Visibility.Visible;
            Homme.Visibility = Visibility.Visible;
            Enfant.Visibility = Visibility.Visible;

            Module_Membre.Visibility = Visibility.Visible;
            CreatMembre.Visibility = Visibility.Visible;
            CreatMembreCommun.Visibility = Visibility.Visible;
            CreatMembreSalar.Visibility = Visibility.Visible;
            textHaut.Text = "Entrer un nouveau salarié";

        }

        private void Membre_Click(object sender, RoutedEventArgs e)
        {
            ToutHide();
            this.salarie = false;

            competbox.Visibility = Visibility.Visible;
            loisirbox.Visibility = Visibility.Visible;

            nonpayee.Visibility = Visibility.Visible;
            payee.Visibility = Visibility.Visible;

            Femme.Visibility = Visibility.Visible;
            Homme.Visibility = Visibility.Visible;
            Enfant.Visibility = Visibility.Visible;

            Module_Membre.Visibility = Visibility.Visible;
            CreatMembre.Visibility = Visibility.Visible;
            CreatMembreCommun.Visibility = Visibility.Visible;
            CreatMembreMembre.Visibility = Visibility.Visible;

            textHaut.Text = "Entrer un nouveau membre";


        }

        private void CotisationPayee(object sender, RoutedEventArgs e)
        {
            this.cotisation = true;
            nonpayee.Visibility = Visibility.Hidden;
        }

        private void CotisationNonPayee(object sender, RoutedEventArgs e)
        {
            this.cotisation = false;
            payee.Visibility = Visibility.Hidden;
        }

        private void Loisir_Click(object sender, RoutedEventArgs e)
        {
            competbox.Visibility = Visibility.Hidden;
            this.titre = "Loisir";
        }

        private void Competition_Click(object sender, RoutedEventArgs e)
        {
            loisirbox.Visibility = Visibility.Hidden;
            this.titre = "Compétition";
        }

        private void MembreSalar(object sender, RoutedEventArgs e)
        {
            smembre = true;
            membresalar.Visibility = Visibility.Hidden;
            nonmembresalar.Visibility = Visibility.Hidden;
            competbox.Visibility = Visibility.Visible;
            loisirbox.Visibility = Visibility.Visible;

            nonpayee.Visibility = Visibility.Visible;
            payee.Visibility = Visibility.Visible;
            CreatMembreMembre.Visibility = Visibility.Visible;
        }

        private void NonMembreSalar(object sender, RoutedEventArgs e)
        {
            smembre = false;
            membresalar.Visibility = Visibility.Hidden;
            nonmembresalar.Visibility = Visibility.Hidden;
        }

        #endregion

        #endregion

        #region Afficher

        public void Afficher(bool salarie) //affiche dans une datagrid permetant la suppression et la modification
        {
            affichagesDatagrid.Items.Refresh();

            if (salarie == false) affichagesDatagrid.ItemsSource = ListStatic.lMembre; 
            else affichagesDatagrid.ItemsSource = ListStatic.lSalarie;

            ToutHide();
            precedent2.Visibility = Visibility.Visible;
            Module_Membre.Visibility = Visibility.Visible;
            ModifierMembre.Visibility = Visibility.Visible;
            affichagesDatagrid.Visibility = Visibility.Visible;

        }

        private void MembreAffiche_Click(object sender, RoutedEventArgs e)
        {
            Afficher(false);
        }

        private void SalarieAffiche_Click(object sender, RoutedEventArgs e)
        {
            Afficher(true);
        }

        #endregion

        #endregion //Terminé //termine

        #region Compétition

        private void ModuleCompet(object sender, RoutedEventArgs e) //afiche grid
        {
            ToutHide();
            Sauvegarde();
            ModuleCompetition.Visibility = Visibility.Visible;
            MenuCompet.Visibility = Visibility.Visible;
        }

        #region Creer Equipe

        private void EntrerNvEquipe(object sender, RoutedEventArgs e)   //creee une equipe a partir des elements entres
                                                                        //Une equipe est un membre avc un nom d'équipe
                                                                        //Il faut une liste d'équipe pour avoir une equipe
        {
            réussite.Text = "";
            string nom = nomMembreEquipe.Text;
            string prenom = prenomMembreEquipe.Text;
            string nomEquipeprov = nomEquipeBox.Text;
            bool existEquipe = false;
            bool exist = false;
            bool dejamembre = false;
            int index = 0;
            Membre membreProv = new Membre(nom, prenom, "", "", "", "", "", "", false, false);
            for (int i = 0; i < ListStatic.lMembre.Count; i++)
            {
                if (membreProv.Equals(ListStatic.lMembre[i]))
                {
                    exist = true;
                    index = i;
                }
            }
            if (exist)
            {
                int index2 = 0;
                for (int i = 0; i < ListStatic.lEquipe.Count; i++)
                {
                    if (nomEquipeprov == ListStatic.lEquipe[i].NomEquipe)
                    {
                        existEquipe = true;
                        index2 = i;
                    }
                }
                if (existEquipe)
                {
                    for (int i = 0; i < ListStatic.lEquipe.Count; i++) if (ListStatic.lEquipe[i].NomEquipe == nomEquipeprov) if (ListStatic.lEquipe[i].Equals(membreProv)) dejamembre = true;
                    if (dejamembre) réussite.Text = "Le joueur saisis est déjà membre";
                    else
                    {
                        réussite.Text = "Joueur inséré avec succès";
                        Equipe newEquipe = new Equipe(nomEquipeprov, ListStatic.lMembre[index].Nom, ListStatic.lMembre[index].Prenom, ListStatic.lMembre[index].Birthday,
                            ListStatic.lMembre[index].Sexe, ListStatic.lMembre[index].Adresse, ListStatic.lMembre[index].Ville, ListStatic.lMembre[index].Telephone,
                            ListStatic.lMembre[index].Titre, ListStatic.lMembre[index].Cotisation, ListStatic.lMembre[index].Capitaine, 0, 0, 0, 0);
                        ListStatic.lEquipe.Add(newEquipe);
                        Sauvegarde();
                    }
                    
                }
                else
                {
                    réussite.Text = "Equipe créée et joueur inséré";
                    Equipe newEquipe = new Equipe(nomEquipeprov, ListStatic.lMembre[index].Nom, ListStatic.lMembre[index].Prenom, ListStatic.lMembre[index].Birthday,
                        ListStatic.lMembre[index].Sexe, ListStatic.lMembre[index].Adresse, ListStatic.lMembre[index].Ville, ListStatic.lMembre[index].Telephone,
                        ListStatic.lMembre[index].Titre, ListStatic.lMembre[index].Cotisation, ListStatic.lMembre[index].Capitaine, 0, 0, 0, 0);
                    ListStatic.lEquipe.Add(newEquipe);
                    Sauvegarde();
                }
            }
            else réussite.Text = "Le joueur n'existe pas";
            nomMembreEquipe.Text = "Nom";
            prenomMembreEquipe.Text = "Prenom";
            nomEquipeBox.Text = "Nom de l'Équipe";

        }

        private void CréerEquipe_Click(object sender, RoutedEventArgs e)
        {
            ToutHide();
            ModuleCompetition.Visibility = Visibility.Visible;
            creerEquipe.Visibility = Visibility.Visible;
            réussite.Text = "";
        }

        #endregion

        #region Creer Compet


        private void CréerCompet_Click(object sender, RoutedEventArgs e) //meme procedure pour equipe
        {
            ToutHide();
            ModuleCompetition.Visibility = Visibility.Visible;
            BoutonD.Visibility = Visibility.Visible;
            BoutonR.Visibility = Visibility.Visible;
            BoutonN.Visibility = Visibility.Visible;
            CreerCompetModule.Visibility = Visibility.Visible;
            Sauvegarde();
        }

        private void CreerCompetClick(object sender, RoutedEventArgs e)
        {
            Sauvegarde();
            BoutonD.Visibility = Visibility.Visible;
            BoutonR.Visibility = Visibility.Visible;
            BoutonN.Visibility = Visibility.Visible;
            reussite.Text = "";
            string nomCompet = nomCompetbox.Text;
            int capacite = Convert.ToInt32(capacitebox.Text);
            int ageMin = Convert.ToInt32(ageMinbox.Text);
            string nomEquipe1 = nomEquipeBox1.Text;
            List<Equipe> listE = new List<Equipe>();



            if (ListStatic.lEquipe != null)
            {
                for (int i = 0; i < ListStatic.lEquipe.Count; i++) if (ListStatic.lEquipe[i].NomEquipe == nomEquipe1) listE.Add(ListStatic.lEquipe[i]); //Equipe
                if (listE.Count == 0 || listE == null) reussite.Text = "L'Équipe voulue n'existe pas, allez dans Créer Équipe";
                else
                {
                    int index = -1;
                    Competition newCompet = new Competition(nomCompet, this.niveau, capacite, ageMin, nomEquipe1, false);
                    for (int i = 0; i < ListStatic.lCompet.Count; i++) if (newCompet.Equals(ListStatic.lCompet[i])) index = i;
                    if (newCompet.CritereAge(listE))
                    {
                        if (index == -1)
                        {
                            reussite.Text = "Compétition créée et équipe insérée";

                        }
                        else
                        {
                            reussite.Text = "Équipe insérée avec succès";
                        }
                        ListStatic.lCompet.Add(newCompet);
                    }
                    else reussite.Text = "Un membre est trop jeune pour particper";

                }
            }
            else reussite.Text = "Aucune équipe créée encore";
            nomCompetbox.Text = "Nom de la compétition";
            capacitebox.Text = "Capacité de la compétition (chiffre)";
            ageMinbox.Text = "Age minimum";
            nomEquipeBox.Text = "Nom de l'équipe";
            Sauvegarde();
        }

        private void regionalClick(object sender, RoutedEventArgs e)
        {
            this.niveau = "Régional";
            BoutonD.Visibility = Visibility.Hidden;
            BoutonN.Visibility = Visibility.Hidden;
        }

        private void departementalClick(object sender, RoutedEventArgs e)
        {
            BoutonR.Visibility = Visibility.Hidden;
            BoutonN.Visibility = Visibility.Hidden;
            this.niveau = "Départemental";
        }

        private void nationalClick(object sender, RoutedEventArgs e)
        {
            BoutonR.Visibility = Visibility.Hidden;
            BoutonD.Visibility = Visibility.Hidden;
            this.niveau = "National";
        }

        #endregion



        #region AfficherEquipe/Compet

        public void AfficherEquipe(bool equipe) //AfficherLes equipes dans une datagrid
        {
            affichagesDatagridCompet.Items.Refresh();
            if (equipe == true) affichagesDatagridCompet.ItemsSource = ListStatic.lEquipe;
            else affichagesDatagridCompet.ItemsSource = ListStatic.lCompet;
            ModuleCompetition.Visibility = Visibility.Visible;
            modifEquipe.Visibility = Visibility.Visible;
            Sauvegarde();
        }

        private void AfficherEquipe(object sender, RoutedEventArgs e)
        {
            ToutHide();
            AfficherEquipe(true);
            Sauvegarde();
        }

        private void AfficherCompet_Click(object sender, RoutedEventArgs e)
        {
            ToutHide();
            AfficherEquipe(false);
            Sauvegarde();
        }

        #endregion

        private void Match_Click(object sender, RoutedEventArgs e)
        {
            ToutHide();
            ModuleCompetition.Visibility = Visibility.Visible;
            gridMatch.Visibility = Visibility.Visible;
            matchs.Items.Refresh();
            Match match1 = new Match();
            ListStatic.lMatch.Add(match1);
            matchs.ItemsSource = ListStatic.lMatch;
        }

        private void MatchValider_Click(object sender, RoutedEventArgs e) //Regarde automatiquement à partir de ce quon a rentre dans la datagrid qui represente le .count-1
                                                                            //Fait tout automatiquement apres avoir rentre
        {
            if (ListStatic.lMatch != null)
            {
                string nom1 = ListStatic.lMatch[ListStatic.lMatch.Count - 1].Nom1;
                string nom2 = ListStatic.lMatch[ListStatic.lMatch.Count - 1].Nom2;
                int count = 0;
                int count2 = 0;
                List<Equipe> lEquipe = new List<Equipe>();
                for (int i = 0; i < ListStatic.lEquipe.Count; i++) if (nom1 == ListStatic.lEquipe[i].NomEquipe) { count++; lEquipe.Add(ListStatic.lEquipe[i]); }
                for (int i = 0; i < ListStatic.lEquipe.Count; i++) if (nom2 == ListStatic.lEquipe[i].NomEquipe) { count2++; lEquipe.Add(ListStatic.lEquipe[i]); }
                if (count != count2) { MatchString.Text = "Les équipes ne jouent pas dans la même catégorie"; }
                else
                {
                    if (count == 1 || count == 2) 
                    {
                        if (count == 1) MatchString.Text = ListStatic.lMatch[ListStatic.lMatch.Count - 1].MatchSimple(lEquipe[0], lEquipe[1]);
                        if (count == 2) MatchString.Text = ListStatic.lMatch[ListStatic.lMatch.Count - 1].MatchDouble(lEquipe[0], lEquipe[1], lEquipe[2], lEquipe[3]);
                    }
                    else
                    {
                        MatchString.Text = "Les équipes ne peuvent jouer dans un match simple ou double";
                    }
                }
            }
        }





        #endregion

        #region Stats Autres et À Propos

        private void ModuleStats(object sender, RoutedEventArgs e)
        {
            ToutHide();

            
            List<Competition> lCompet2 = new List<Competition>();
            for (int i = 0; i < ListStatic.lCompet.Count; i++)
            {
                lCompet2.Add(ListStatic.lCompet[i]);
            }

            List<Equipe> lEquipe2 = new List<Equipe>();
            for (int i = 0; i < ListStatic.lEquipe.Count; i++)
            {
                lEquipe2.Add(ListStatic.lEquipe[i]);
            }

            Statistiques.Visibility = Visibility.Visible;
            Statistique s = new Statistique();
            if (ListStatic.lStat.Count != 0) ListStatic.lStat.Remove(s);
            s.RvsAFAire(lCompet2);
            s.MoyenJparCompet(lEquipe2, lCompet2);
            s.StatCompetClub(lEquipe2);
            s.RepartitionParCategorie(lEquipe2);

            ListStatic.lStat.Add(s);

            StatDataGrid.Items.Refresh();
            StatDataGrid.ItemsSource = ListStatic.lStat;

        }

        private void ModuleAutre(object sender, RoutedEventArgs e)
        {
            ToutHide();
            ModuleAutres.Visibility = Visibility.Visible;
            MenuAutres.Visibility = Visibility.Visible;
            Sauvegarde();
        }
        
        

        #region Boutons

        private void AfficherAdministration(object sender, RoutedEventArgs e)
        {
            Fond1.Visibility = Visibility.Hidden;
            Fond3.Visibility = Visibility.Hidden;
            Fond2.Visibility = Visibility.Visible;

        }

        private void AfficherEntraineurs(Object sender, RoutedEventArgs e)
        {
            Fond1.Visibility = Visibility.Hidden;
            Fond3.Visibility = Visibility.Visible;
            Fond2.Visibility = Visibility.Hidden;

        }

        private void AfficherEvents(Object sender, RoutedEventArgs e)
        {
            Fond1.Visibility = Visibility.Visible;
            Fond3.Visibility = Visibility.Hidden;
            Fond2.Visibility = Visibility.Hidden;
        }

        private void Stage(Object sender, RoutedEventArgs e)
        {
            ToutHide();
            dataAutres.Items.Refresh();
            ModuleAutres.Visibility = Visibility.Visible;
            dataGridAutre.Visibility = Visibility.Visible;
            dataAutres.ItemsSource = ListStatic.lJunior;
        }



        #endregion
        #region A Propos

        private void APropos(object sender, RoutedEventArgs e)
        {
            ToutHide();
            AProposGrid.Visibility = Visibility.Visible;
        }

        private void UML(object sender, RoutedEventArgs e)
        {
            Process.Start("UML.pdf");
        }

        private void Rapport(object sender, RoutedEventArgs e)
        {
            Process.Start("RAPPORT-DE-LA-SOLUTION.pdf");
        }

        #endregion

        #endregion

        #region Hide

        public void ToutHide()
        {
            MenuPrincipal.Visibility = Visibility.Hidden;

            Module_Membre.Visibility = Visibility.Hidden;

            ModifierMembre.Visibility = Visibility.Hidden;
            TextePrincipalMembre.Visibility = Visibility.Hidden;
            CreatMembre.Visibility = Visibility.Hidden;
            CreatMembreCommun.Visibility = Visibility.Hidden;
            CreatMembreSalar.Visibility = Visibility.Hidden;
            CreatMembreMembre.Visibility = Visibility.Hidden;

            ModuleCompetition.Visibility = Visibility.Hidden;
            gridMatch.Visibility = Visibility.Hidden;
            MenuCompet.Visibility = Visibility.Hidden;
            modifEquipe.Visibility = Visibility.Hidden;
            creerEquipe.Visibility = Visibility.Hidden;

            CreerCompetModule.Visibility = Visibility.Hidden;

            Statistiques.Visibility = Visibility.Hidden;

            ModuleAutres.Visibility = Visibility.Hidden;
            dataGridAutre.Visibility = Visibility.Hidden;
            MenuAutres.Visibility = Visibility.Hidden;

            AProposGrid.Visibility = Visibility.Hidden;
            
        }




        #endregion

        

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
