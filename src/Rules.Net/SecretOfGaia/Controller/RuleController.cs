using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecretOfGaia.Controller
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
        #endregion


        #region "Proprités publiques"

        public int numTour
        {
            get
            {
                return _numTour;
            }
        }
        public static int cartesDeDepartPourDuo = 3;
        public static int cartesDeDepartBonusJoueur2 = 1;
        #endregion

        #region "Constructeurs"

        public RuleController()
        {
        }

        #endregion


        #region "Methodes privées"
        protected void demarrerTourJoueur1()
        {
            
            _joueur1.piocherCartes();
            _joueur1.appliquerModificateur(_plateau.terrainsJoueur1.totalModificateurJoueur);
            //_joueur1.AppliquerModificateur(_plateau.terrainsJoueur2.totalModificateurAdversaire);
            

        }

        protected void demarrerLeJeu()
        {
            _numTour = 0;
            _plateau = new Plateau(_joueur1,_joueur2);
            demarrerUnTour();
        }
        #endregion


        #region "Méthode publiques"
        public void demarerDuel(Joueur curJoueur1, Joueur curJoueur2)
        {
            _joueur1 =  curJoueur1 ;
            _joueur2 =  curJoueur2 ;

            _joueur1.piocherCartes(cartesDeDepartPourDuo);
            _joueur2.piocherCartes(cartesDeDepartPourDuo + cartesDeDepartBonusJoueur2);

            demarrerLeJeu();
        }

        public void demarrerUnTour()
        {
            _numTour++;
            demarrerTourJoueur1();
        }


        #endregion

    }
}






