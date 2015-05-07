using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.App
{
    public class HandDiscriminator
    {
        public HandType getHandType(int[] cards)
        {
            var cardGroups = cards.GroupBy(card => card);
            var pairedCardGroups = cardGroups.Where(cardGroup => cardGroup.Count() == 2);
            if (pairedCardGroups.Count() == 2)
            {
                return HandType.Perechi;
            }

            var cuie = cardGroups.Where(cardGroup => cardGroup.Count() == 3);
            if(cuie.Count() == 1)
            {
                if (pairedCardGroups.Count() == 1)
                {
                    return HandType.FullHouse;
                }
                return HandType.Cui;
            }

            if (pairedCardGroups.Count() == 1)
            {
                return HandType.Pereche;
            }

            var careu = cardGroups.Where(cardGroup => cardGroup.Count() == 4);
            if(careu.Count() == 1)
            {
                return HandType.Careu;
            }

            var orderedCards = cards.OrderBy(card => card);

            var cardPairs = orderedCards.ConsecutivePairs();

            var isChinta = cardPairs.All(pair => pair.Item2 - pair.Item1 == 1);
            
            if(isChinta)
            {
                return HandType.Chinta;
            }

            return HandType.Nimic;
        }

        public HandType getHandType(Card[] hand)
        {
            //varianta groupby
            //var groupedCards = hand.GroupBy(card => card.simbol);
            //if(groupedCards.Count() == 1)
            //{
            //    return HandType.Culoare;
            //}

            //varianta select
            var distinctSimbols = hand.Select(card => card.simbol).Distinct();

            if(distinctSimbols.Count() == 1)
            {
                var cardValues = hand.Select(card => card.valoare).ToArray();
                if(getHandType(cardValues).Equals(HandType.Chinta))
                {
                    return HandType.ChintaCuloare;
                }
                return HandType.Culoare;
            }



            return HandType.Nimic; 
        }
    }
    public enum HandType { 
        Pereche, 
        Perechi, 
        Cui, 
        Culoare, 
        FullHouse, 
        Careu, 
        Chinta,
        ChintaCuloare,
        Nimic
    };
}
