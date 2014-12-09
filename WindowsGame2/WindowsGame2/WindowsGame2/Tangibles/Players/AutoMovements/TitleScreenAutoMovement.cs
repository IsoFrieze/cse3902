using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class TitleScreenAutoMovement : IAutoMovement
    {
        public IPlayer Player { get; set; }
        public bool IsActive { get; set; }
        List<Tuple<ICommand, int>> moves;
        private int i, j;

        public TitleScreenAutoMovement(IPlayer player)
        {
            this.IsActive = true;
            this.Player = player;
            this.moves = new List<Tuple<ICommand, int>>()
            {
                new Tuple<ICommand, int>(new NoPlayerActionCommand(Player), 1),
            };
            this.i = 0;
            this.j = 0;
        }

        public void Update()
        {
            Tuple<ICommand, int> t = moves[i];

            CommandScheduler.Queue(t.Item1, this);

            j++;
            if (j == t.Item2)
            {
                j = 0;
                i++;
            }
            if (i == moves.Count)
            {
                IsActive = false;
            }
        }
    }
}
