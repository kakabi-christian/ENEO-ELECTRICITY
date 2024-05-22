using System;
using System.IO;
using System.Windows.Forms;

namespace Projet_eneo
{
    public partial class Form1 : Form

    {
        private CalculateurFacture calculateurFacture;
        private Client client;
        private Facture facture;
        public Form1()
        {
            InitializeComponent();
            calculateurFacture = new CalculateurFacture();

        }

        private void ActiverDesactiverControls(bool enable)
        {
            txtNom.ReadOnly = !enable;
            txtPrenom.ReadOnly = !enable;
            txtVille.ReadOnly = !enable;
            txtQuartier.ReadOnly = !enable;
            txtIdentifiant.ReadOnly = !enable;
            txtConsommation.ReadOnly = !enable;
            basse_tension.Enabled = enable;
            moyenne_tension.Enabled = enable;
            rtbfacture.ReadOnly = !enable;
        }

        private void btnCalculer_Click(object sender, EventArgs e)
        {
            string nomClient = txtNom.Text;
            string prenomClient = txtPrenom.Text;
            string villeClient = txtVille.Text;
            string quartierClient = txtQuartier.Text;
            string identifantClient = txtIdentifiant.Text;
            int consommation;
      
            if (int.TryParse(txtConsommation.Text , out consommation) && consommation >=0)
            {
                double montantTotal;

                if (rbBT.Checked)
                {
                    montantTotal = calculateurFacture.CalculerFactureBT(consommation);
                }
                else if(rbMT.Checked)
                {
                    montantTotal = calculateurFacture.CalculerFactureMT(consommation);
                }
                else
                {
                    MessageBox.Show("veuillez selectionner une categorie de client.", "erreur", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    return;
                }

                client = new Client (prenomClient, villeClient, quartierClient, identifantClient, consommation, nomClient);
                facture = new Facture(client, montantTotal);
                rtbfacture.Text = facture.GenererContenu();

            }
            else
            {
                MessageBox.Show("veuillez saisir une consommation valide ", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            ActiverDesactiverControls(true);
            MessageBox.Show("vous pouvez maintenant modifier la facture.", "modification", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information);
        }
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            string nomClient = txtNom.Text;
            string prenomClient = txtPrenom.Text;
            string villeClient = txtVille.Text;
            string quartierClient = txtQuartier.Text;
            string identifantClient = txtIdentifiant.Text;
            int consommation;
            if (int.TryParse(txtConsommation.Text, out consommation) && consommation >= 0)
            {
                double montantTotal;

                if (rbBT.Checked)
                {
                    montantTotal = calculateurFacture.CalculerFactureBT(consommation);
                }
                else if (rbMT.Checked)
                {
                    montantTotal = calculateurFacture.CalculerFactureMT(consommation);
                }
                else
                {
                    MessageBox.Show("veuillez selectionner une categorie de client.", "erreur", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    return;
                }

                client = new Client(prenomClient, villeClient, quartierClient, identifantClient, consommation, nomClient);
                facture = new Facture(client, montantTotal);
                rtbfacture.Text = facture.GenererContenu();

            }
            else
            {
                MessageBox.Show("veuillez saisir une consommation valide .", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ActiverDesactiverControls(false);
            string dateEmission = DateTime.Now.ToString("yyyyMMdd");
            string nomFichier = "facture" + txtIdentifiant.Text + "_" + dateEmission;
            int numSequence = 1;
            string cheminFichier;
            do
            {
                

                cheminFichier =   Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), nomFichier + "_" + numSequence + ".txt");
                if (!File.Exists(cheminFichier))
                {
                    break;
                }
                numSequence++;
            } while (true);
            File.WriteAllText(cheminFichier, rtbfacture.Text);
            MessageBox.Show("la nodification de de la lecturre a ete enregistrer dans : " + cheminFichier, "modification enregistre ", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btncharger_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "fichiers texte(*.txt)|*.txt|tous les fichiers (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true

            };
            if(openFileDialog.ShowDialog() ==DialogResult.OK)
            {
                try
                {
                    string contenuFacture = File.ReadAllText(openFileDialog.FileName);
                    rtbfacture.Text = contenuFacture;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("une erreur s'est produite lors du chargement de votre fichier : " + ex.Message, "errer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
       

        
      
 
       