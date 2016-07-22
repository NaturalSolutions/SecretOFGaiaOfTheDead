using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecretOfGaia
{
    /// <summary>
    /// 
    /// </summary>
    public class Terrain : InventaireDeCarte
    {


        #region "Propriétés privées"
        /// <summary>
        /// 
        /// </summary>
        protected int _taille;

        /// <summary>
        /// clé: carte supperposée, valeur, carte sur laquelle est superposée
        /// </summary>
        protected Dictionary<int, List<Carte>> _cartesSupreposées;
        #endregion


        #region "Proprités publiques"
        /// <summary>
        /// 
        /// </summary>
        public int taille
        {
            get
            {
                return _taille;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override int Count
        {
            get
            {
                return _cartes.Where(s => s.Value != null).Count();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public int CountTotal
        {
            get
            {
                return (base.Count + _cartesSupreposées.Count);
            }
        }

        public override Carte this[int position]
        {
            get
            {
                if (_cartesSupreposées.ContainsKey(position))
                {
                    return _cartesSupreposées[position].Last();
                }
                else
                {
                    return base[position];
                }
            }
        }
        #endregion

        #region "Constructeurs"
        public Terrain(int curTaille)
            : base()
        {

            _taille = curTaille;
            _cartesSupreposées = new Dictionary<int, List<Carte>>();
            for (int i = 1; i <= curTaille; i++)
            {
                _cartes[i] = null;
            }

        }
        #endregion


        #region "Methodes privées"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        protected Carte enleverCarteSuperposée(int position)
        {
            Carte retour;
            if (_cartesSupreposées.ContainsKey(position))
            {
                retour = _cartesSupreposées[position].Last();
                _cartesSupreposées[position].RemoveAt(_cartesSupreposées[position].Count - 1);
                if (_cartesSupreposées[position].Count == 0)
                {
                    _cartesSupreposées.Remove(position);
                }
                return retour;
            }
            else
            {
                return null;
            }
        }

        #endregion


        #region "Méthode publiques"

        public List<int> positionsLibres
        {
            get
            {
                return _cartes.Where(s => s.Value == null).Select(s => s.Key).ToList();
            }
        }

        public override bool ajouterCarte(Carte curCarte)
        {

            
            if (positionsLibres.Count == 0)
            {
                return false;
            }
            int positionLibre = positionsLibres.First();
            _cartes[positionLibre] = curCarte;
            return true;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public override Carte enleverCarte(int position)
        {
            return enleverCarte(position, false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="isCarteduDessous"></param>
        /// <returns></returns>
        public Carte enleverCarte(int position, bool isCarteduDessous)
        {
            if (_cartes.ContainsKey(position))
            {
                if (_cartesSupreposées.ContainsKey(position))
                {// S'il y des cartes posées sur la carte
                    if (isCarteduDessous)
                    {// Si on enlève la carte du dessous
                        // on enlève toutes les cartes posée dessus et on enlève la carte
                        _cartesSupreposées.Remove(position);
                        return base.enleverCarte(position);
                    }
                    else
                    {// sinon on enleve la carte du dessus
                        return this.enleverCarteSuperposée(position);
                    }
                }
                else
                {// Si pas de carte superposé, on applique la méthode du parent
                    return base.enleverCarte(position);
                }
            }
            else
            {
                return null ;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="curCarte"></param>
        /// <returns></returns>
        public bool poserSur(int position, Carte curCarte)
        {
            if (_cartes.ContainsKey(position))
            {
                if (!_cartesSupreposées.ContainsKey(position))
                {
                    _cartesSupreposées[position] = new List<Carte>();
                }
                _cartesSupreposées[position].Add(curCarte);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Carte carteduBasAPosition(int position)
        {
            return base[position];
        }
        #endregion

    }
}






