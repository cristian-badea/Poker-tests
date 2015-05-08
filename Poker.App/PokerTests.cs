using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace Poker.App
{
    public class PokerTests
    {
        public void OnePair()
        {
            int[] cards = new int[]{2,2,3,5,7};

            HandDiscriminator discriminator = new HandDiscriminator();

            HandType message = discriminator.getHandType(cards);
            message.ShouldBe(HandType.Pereche);

        }
        public void TwoPairs()
        {
            int[] cards = new int[] { 2, 2, 3, 3, 7 };

            HandDiscriminator discriminator = new HandDiscriminator();

            HandType message = discriminator.getHandType(cards);
            message.ShouldBe(HandType.Perechi);

        }
        public void Cui()
        {
            int[] cards = new int[] { 2, 2, 2, 5, 7 };

            HandDiscriminator discriminator = new HandDiscriminator();

            HandType message = discriminator.getHandType(cards);
            message.ShouldBe(HandType.Cui);

        }
        public void FullHouse()
        {
            int[] cards = new int[] { 2, 2, 3, 3, 3 };

            HandDiscriminator discriminator = new HandDiscriminator();

            HandType message = discriminator.getHandType(cards);
            message.ShouldBe(HandType.FullHouse);

        }
        public void Careu()
        {
            int[] cards = new int[] { 2, 2, 2, 2, 3 };

            HandDiscriminator discriminator = new HandDiscriminator();

            HandType message = discriminator.getHandType(cards);
            message.ShouldBe(HandType.Careu);

        }
        public void Chinta()
        {
            int[] cards = new int[] {2,4,5,3,6};

            HandDiscriminator discriminator = new HandDiscriminator();

            HandType message = discriminator.getHandType(cards);
            message.ShouldBe(HandType.Chinta);
        }
        public void Culoare()
        {
            Card[] cards = new Card[]
            {
                new Card(2,"Pica"),
                new Card(5,"Pica"),
                new Card(3,"Pica"),
                new Card(1,"Pica"),
                new Card(7,"Pica"),
            };

            HandDiscriminator discriminator = new HandDiscriminator();

            HandType message = discriminator.getHandType(cards);
            message.ShouldBe(HandType.Culoare);
        }

        public void ChintaCuloare()
        {
            Card[] cards = new Card[]
            {
                new Card(3,"Pica"),
                new Card(5,"Pica"),
                new Card(4,"Pica"),
                new Card(7,"Pica"),
                new Card(6,"Pica"),
            };

            HandDiscriminator discriminator = new HandDiscriminator();

            HandType message = discriminator.getHandType(cards);
            message.ShouldBe(HandType.ChintaCuloare);
        }
    }
}
