using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SecretOfGaia;

public class GameStarter
{
    public static Carte getCarte(string NomCarte)
    {
        switch (NomCarte)
        {
            case "Guêpe":
                return new Carte("Guêpe", TypeCarte.Instantanee, 5, 0, 5);
            case "Mante religieuse":
                return new Carte("Mante religieuse", TypeCarte.Instantanee, 3, 0, 2);
            case "Goéland leucophée":
                return new Carte("Goéland leucophée", TypeCarte.Instantanee, 4, 0, 2);
            case "Immortelle des dunes":
                Dictionary<string, decimal> modifJoueur = new Dictionary<string, decimal>{
                        {"PV",1},
                    };
                return new Carte("Immortelle des dunes", TypeCarte.Permanente, 4, 0, 4, curmodificateurJoueur: modifJoueur);
            case "Figuier de Barbarie":
                return new Carte("Figuier de Barbarie", TypeCarte.Retarde, 0, 3, 3);
            default:
                return new Carte("Guêpe", TypeCarte.Instantanee, 5, 0, 4);
        }
    }


    public static  Deck construireUnDeck(Dictionary<string, int> ListeCarte)
    {
        Deck monDeck = new Deck();
        foreach (string clef in ListeCarte.Keys)
        {
            for (int i = 0; i < ListeCarte[clef]; i++)
            {
                monDeck.ajouterCarte(getCarte(clef));
            }
        }
        return monDeck;

    }

    public static Joueur obtenirJoueur2()
    {
        Deck DeckJoueur2 = construireUnDeck(new Dictionary<string, int>{
                {"Guêpe",10},
                {"Mante religieuse",5},
                {"Goéland leucophée",5}
            });

        Dictionary<string, CaracteristiqueJoueur> caracs = new Dictionary<string, CaracteristiqueJoueur> {
                {"Force",new CaracteristiqueJoueur(8)}
                ,{"PV",new CaracteristiqueJoueur(22)}
            };
        Joueur MonJoueur = new Joueur("JoueurTest1", curCaracs: caracs, curDecks: new List<Deck> { DeckJoueur2 });
        return MonJoueur;
    }

    public static Joueur obtenirJoueur1()
    {

        Deck DeckJoueur1 = construireUnDeck(new Dictionary<string, int>{
                {"Guêpe",5},
                {"Mante religieuse",10},
                {"Goéland leucophée",3}
            });



        Dictionary<string, CaracteristiqueJoueur> caracs = new Dictionary<string, CaracteristiqueJoueur> {
                {"Force",new CaracteristiqueJoueur(5)}
                ,{"PV",new CaracteristiqueJoueur(15)}
            };
        Joueur MonJoueur1 = new Joueur("JoueurTest1", curCaracs: caracs, curDecks: new List<Deck> { DeckJoueur1 });
        return MonJoueur1;
    }


}

