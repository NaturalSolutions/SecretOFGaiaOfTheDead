using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecretOfGaia
{
    /// <summary>
    /// 
    /// </summary>
    public class RuleController
    {


        #region "Propriétés privées"
        protected int _numTour;
        protected Joueur _joueur1;
        protected Joueur _joueur2;
        protected Plateau _plateau;

        protected Joueur _joueurActif;
        protected Dictionary<int, int> _actionParTour;

        #endregion


        #region "Proprités publiques"


        public int nbAction
        {
            get
            {

                if (numTour > _actionParTour.Keys.Max())
                {
                    // si au délà du tablau: action MAx
                    return _actionParTour.Values.Max();
                }
                else
                {
                    return _actionParTour[numTour];
                }
            }
        }


        public int numTour
        {
            get
            {
                return _numTour;
            }
        }
        public static int cartesDeDepartPourDuo = 3;
        public static int cartesDeDepartBonusJoueur2 = 1;

        public Joueur joueurActif
        {
            get
            {
                return _joueurActif;
            }
        }

        public Joueur adversaireActif
        {
            get
            {
                if (_joueurActif == _joueur1) return _joueur2;
                return joueur1;
            }
        }


        public Plateau plateau
        {
            get
            {
                return _plateau;
            }
        }

        public Terrain terrainJoueurActif
        {
            get
            {
                if (_joueurActif == joueur1)
                {
                    return plateau.terrainsJoueur1;
                }
                else
                {
                    return plateau.terrainsJoueur2;
                }
            }
        }
        public Joueur joueur1
        {
            get
            {
                return _joueur1;
            }

        }

        public Joueur joueur2
        {
            get
            {
                return _joueur2;
            }

        }

        #endregion

        #region "Constructeurs"

        public RuleController()
        {

            _actionParTour = new Dictionary<int, int>{
                {1,3},
                {2,4},
                {3,5},
                {4,6}
            };
        }

        #endregion


        #region "Methodes privées"

        protected void demarrerTourJoueur(int numJoueur)
        {
            if (numJoueur == 1)
            {
                _joueurActif = _joueur1;
                joueurActif.appliquerModificateur(_plateau.terrainsJoueur1.totalModificateurJoueur);
                joueurActif.appliquerModificateur(_plateau.terrainsJoueur2.totalModificateurAdversaire);
            }
            else
            {
                _joueurActif = _joueur2;
                joueurActif.appliquerModificateur(_plateau.terrainsJoueur2.totalModificateurJoueur);
                joueurActif.appliquerModificateur(_plateau.terrainsJoueur1.totalModificateurAdversaire);
            }
            

            joueurActif.piocherCartes();

            joueurActif.appliquerModificateur(new Dictionary<string, decimal>
            {
                {"actions",this.nbAction }
            },surValeurMax:true);
            

        }

        protected void demarrerLeJeu()
        {
            _numTour = 0;
            _plateau = new Plateau(_joueur1,_joueur2);
           
            demarrerUnTour();
        }

        protected void AppliquerCarte(Carte curCarte)
        {
            joueurActif.appliquerModificateur(new Dictionary<string, decimal>{
                {"PV",curCarte.soin},
            });

            adversaireActif.appliquerModificateur(new Dictionary<string, decimal>{
                {"PV",-curCarte.attaque}
            });

            joueurActif.appliquerModificateur(curCarte.modificateurJoueur);
            adversaireActif.appliquerModificateur(curCarte.modificateurAdversaire);
        }

        

        #endregion


        #region "Méthode publiques"
        public void demarerDuel(Joueur curJoueur1, Joueur curJoueur2)
        {
            _joueur1 =  curJoueur1 ;
            _joueur2 =  curJoueur2 ;

            _joueur1.deckActif.battreLesCartes();
            _joueur2.deckActif.battreLesCartes();

            _joueur1.piocherCartes(cartesDeDepartPourDuo);
            _joueur2.piocherCartes(cartesDeDepartPourDuo + cartesDeDepartBonusJoueur2);

            demarrerLeJeu();
        }

        public void demarrerUnTour()
        {
            _numTour++;
            
            demarrerTourJoueur(1);
        }


        public void finTourJoueur1()
        {

            //TODO gestion des actions conservées
            _joueur1.appliquerModificateur(new Dictionary<string, decimal>
            {
                {"actions",0}
            }, valeurRelative: false);
            demarrerTourJoueur(2);

        }

        public void finTourJoueur2()
        {

            //TODO gestion des actions conservées
            _joueur2.appliquerModificateur(new Dictionary<string, decimal>
            {
                {"actions",0}
            }, valeurRelative: false);
            demarrerUnTour();

        }


        public Carte jouerUneCarteDepuisLaMain(string nomCarte)
        {
            Carte curCarte = joueurActif.cartesEnMain[nomCarte] ;
            
            if (curCarte == null) return null ;
            return jouerUneCarteDepuisLaMain(curCarte); 
            
            

            
        }

        public Carte jouerUneCarteDepuisLaMain(Carte maCarte)
        {
            if (maCarte.action > joueurActif["actions"])
            {
                return null;
            }
            Carte curCarte = joueurActif.cartesEnMain.enleverCarte(maCarte);
            if (curCarte == null)
            {
                return null;
            }

            if ((curCarte.TypeCarte & TypeCarte.Instantanee) == 0)
            {
                // Carte à ,poser du le terrain
                if (terrainJoueurActif.positionsLibres.Count() == 0)
                {
                    return null;
                }
                else
                {
                    terrainJoueurActif.ajouterCarte(curCarte);
                }
            }
            else
            {
                AppliquerCarte(curCarte);
            }

            joueurActif.appliquerModificateur(new Dictionary<string, decimal>{
                {"actions",-curCarte.action}
            });

            return curCarte;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nomCarte"></param>
        /// <returns></returns>
        public Carte jouerUneCarteDepuisLePlateau(string nomCarte)
        {
            Carte curCarte = terrainJoueurActif[nomCarte];
            return jouerUneCarteDepuisLePlateau(curCarte);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="curCarte"></param>
        /// <returns></returns>
        public Carte jouerUneCarteDepuisLePlateau(Carte curCarte)
        {
            if (curCarte == null || (curCarte.TypeCarte & TypeCarte.Retarde) == 0) return null;
            terrainJoueurActif.PrendreUneCarte(curCarte);
            AppliquerCarte(curCarte);

            return curCarte;
        }


        

        #endregion

    }
}






