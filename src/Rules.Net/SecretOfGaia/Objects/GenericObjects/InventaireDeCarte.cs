using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecretOfGaia
{
    /// <summary>
    /// 
    /// </summary>
    public class InventaireDeCarte
    {

        #region "Propriétés privées"
        protected Dictionary<int, Carte> _cartes;
        #endregion


        #region "Proprités publiques"

        /// <summary>
        /// 
        /// </summary>
        public virtual int Count
        {
            get
            {
                return _cartes.Count;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, decimal> totalModificateurJoueur
        {
            get
            {

                return getTotalModificateur(false);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, decimal> totalModificateurAdversaire
        {
            get
            {

                return getTotalModificateur(true);
            }
        }



        /// <summary>
        /// 
        /// </summary>
        public Carte prochaineCarte
        {
            get
            {
                if (_cartes.Count == 0)
                {
                    return null;
                }
                else
                {
                    return this._cartes[this._cartes.Keys.Min()];
                }
            }
        }
        #endregion

        #region "Constructeurs"
        /// <summary>
        /// 
        /// </summary>
        public InventaireDeCarte()
        {
            _cartes = new Dictionary<int, Carte>();
        }
        #endregion


        #region "Methodes privées"
        public Dictionary<string, decimal> getTotalModificateur(bool pourAdversaire = false)
        {
            Dictionary<string, decimal> curModifs = new Dictionary<string, decimal>();
            foreach (Carte curCarte in _cartes.Values.Where(s => s != null && s.TypeCarte == TypeCarte.Permanente))
            {
                Dictionary<string, decimal> boni;
                if (pourAdversaire)
                {
                    boni = curCarte.modificateurJoueur;
                }
                else
                {
                    boni = curCarte.modificateurAdversaire;
                }
                foreach (string nomModif in boni.Keys)
                {
                    if (curModifs.ContainsKey(nomModif))
                    {
                        curModifs[nomModif] = curModifs[nomModif] + boni[nomModif];
                    }
                    else
                    {
                        curModifs[nomModif] = boni[nomModif];
                    }
                }

            }
            return curModifs;
        }
        #endregion


        #region "Méthode publiques"



        /// <summary>
        /// 
        /// </summary>
        /// <param name="NumCarte"></param>
        /// <returns></returns>
        public virtual Carte this[int position]
        {
            get
            {
                return _cartes[position];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NomCarte"></param>
        /// <returns></returns>
        public Carte this[string NomCarte]
        {
            get
            {
                return _cartes.Select(s => s.Value).Where(s => s.nom.ToLower() == NomCarte.ToLower()).FirstOrDefault();
            }
        }



        public virtual bool ajouterCarte(Carte curcarte)
        {
            _cartes.Add(_cartes.Keys.DefaultIfEmpty(0).Max() + 1, curcarte);
            return true;
        }

        public virtual bool ajouterCarte(Carte curcarte, int position = - 1, bool remplaceExistante = true)
        {
            if (position == -1)
            {
                position = _cartes.Keys.DefaultIfEmpty(0).Max() + 1;
            }
            if (_cartes.ContainsKey(position))
            {
                if (remplaceExistante)
                {
                    _cartes.Remove(position);
                }
                else
                {
                    return false;
                }
            }
            _cartes[position] = curcarte;
            return true;
        }


        public virtual Carte enleverCarte(int position)
        {
            Carte Resultat;
            if (_cartes.ContainsKey(position))
            {
                Resultat = _cartes[position];
                _cartes.Remove(position);
                return Resultat;
            }
            else
            {
                return null;
            }
        }


        public virtual Carte enleverCarte(Carte curCarte)
        {
            int positonCarte = _cartes.Where(s => s.Value == curCarte).Select(s => s.Key).FirstOrDefault();
            if (positonCarte == null)
            {
                return null;
            }
            else
            {

                _cartes.Remove(positonCarte);
                return curCarte;
            }
        }


        public virtual Carte PrendreProchaineCarte()
        {
            // TODO Gérer le cas ou l'inventair est vide
            Carte premiereCarte = _cartes[_cartes.Keys.Min()];
            _cartes.Remove(_cartes.Keys.Min());
            return premiereCarte;
        }

        public virtual Carte PrendreUneCarte(Carte curCarte)
        {

            return enleverCarte(curCarte); ;
        }


        public virtual List<Carte> ToList()
        {
            return _cartes.Select(s => s.Value).ToList();
        }


        public virtual void battreLesCartes()
        {
            Dictionary<int, Carte> nouvellesCartes = new Dictionary<int, Carte>();
            Random rnd = new Random();
            int nouvellePosition = 1;
            while (_cartes.Count > 0)
            {
                int positionChoisie = rnd.Next(0, _cartes.Keys.Count - 1);
                int position = _cartes.Keys.ToList()[positionChoisie];
                nouvellesCartes.Add(nouvellePosition, _cartes[position]);
                _cartes.Remove(position);
                nouvellePosition++;
            }
            _cartes = nouvellesCartes;
        }
        #endregion

    }
}
