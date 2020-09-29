using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Card
    {
        public int CardValue { get; set; }
        public string Suit { get; set; }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Card);
        }

        public bool Equals(Card other)
        {
            if (other == null)
                return false;

            return this.Suit.Equals(other.Suit) &&
                (
                    object.ReferenceEquals(this.CardValue, other.CardValue) ||
                    this.CardValue != null &&
                    this.CardValue.Equals(other.CardValue)
                ) &&
                (
                    object.ReferenceEquals(this.Name, other.Name) ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                );
        }
    }
}
