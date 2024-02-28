using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace DiscordBot.commands
{
    internal class Commandz : BaseCommandModule
    {
        public int xPos;
        public int yPos;
        public int eX;
        public int eY;
        public List<string> row = new List<string>();

        [Command("add")]
        public async Task Add(CommandContext ctx, int num1, int num2)
        {
            int result = num1 + num2;

            await ctx.Channel.SendMessageAsync(result.ToString());
        }

        [Command("Game_RPSTut")]
        public async Task Game_RPSTut(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync(
                "Type in Game_RPS, then put a space between and write exactly like this ---> ( Rock, Paper, Scissors )!");
        }

        [Command("Game_RPS")]
        public async Task Game_RPS(CommandContext ctx, string hit)
        {
            string[] all = { "Rock", "Paper", "Scissors" };
            int Winner = 0;

            Random rnd = new Random();
            int chance = rnd.Next(0, 45);

            if (chance <= 15 && hit == "Rock")
            {
                await ctx.Channel.SendMessageAsync("Tie");
            }

            if (chance > 15 && chance < 30 && hit == "Rock")
            {
                await ctx.Channel.SendMessageAsync("Lose");
            }

            if (chance > 30 && chance <= 45 && hit == "Rock")
            {
                await ctx.Channel.SendMessageAsync("Win");
            }

            if (chance <= 15 && hit == "Paper")
            {
                await ctx.Channel.SendMessageAsync("Win");
            }

            if (chance > 15 && chance < 30 && hit == "Paper")
            {
                await ctx.Channel.SendMessageAsync("Tie");
            }

            if (chance > 30 && chance <= 45 && hit == "Paper")
            {
                await ctx.Channel.SendMessageAsync("Lose");
            }

            if (chance <= 15 && hit == "Scissors")
            {
                await ctx.Channel.SendMessageAsync("Lose");
            }

            if (chance > 15 && chance < 30 && hit == "Scissors")
            {
                await ctx.Channel.SendMessageAsync("Win");
            }

            if (chance > 30 && chance <= 45 && hit == "Scissors")
            {
                await ctx.Channel.SendMessageAsync("Tie");
            }

            if (hit == "")
            {
                await ctx.Channel.SendMessageAsync("Please Type in one of these ---> ( Rock, Paper, Scissors ) <--- to play! ");
            }

            await ctx.Channel.SendMessageAsync($"Random Number: {chance}");
        }

        [Command("Reset")]
        public async Task Reset(CommandContext ctx)
        {
            
            Random rnd = new Random();
            int rand1 = rnd.Next(0, 5);
            int rand2 = rnd.Next(0, 5);
            int rand3 = rnd.Next(0, 5);
            int rand4 = rnd.Next(0, 5);

            xPos = rand1; 
            yPos = rand2;

            eX = rand3;
            eY = rand4;

            for (int y = 0; y < 5; y++)
            {
                row.Clear();

                for (int x = 0; x < 5; x++)
                {
                    if (x == xPos && y == yPos)
                    {
                        row.Add(":red_square:");
                    }
                    else if (eX == x && eY == y)
                    {
                        row.Add(":green_square:");
                    }
                    else
                    {
                        row.Add(":blue_square:");
                    }
                }
                await ctx.Channel.SendMessageAsync(string.Join("", row));
            }

            await ctx.Channel.SendMessageAsync($"xPos: { xPos }");
            await ctx.Channel.SendMessageAsync($"yPos: { yPos }");
            await ctx.Channel.SendMessageAsync($"EnemyX: { eX }");
            await ctx.Channel.SendMessageAsync($"EnemyY: { eY }");
        }

        [Command("Player")]
        public async Task Player(CommandContext ctx, string move)
        {
            // this is the players movement & playspace so he/she doesnt move out the playspace
            if (move != "still")
            {
                if (move == "left")
                {
                    xPos -= 1;
                }

                if (move == "right")
                {
                    xPos += 1;
                }

                if (move == "up")
                {
                    yPos -= 1;
                }

                if (move == "down")
                {
                    yPos += 1;
                }
            }

            if ( xPos > 4 )
            {
                xPos = 4;
            }
            if ( xPos < 0 )
            {
                xPos = 0;
            }

            if ( yPos > 4 )
            {
                yPos = 4;
            }
            if ( yPos < 0 )
            {
                yPos = 0;
            }

            // This is the enemies movement & barrier so he/she doesnt move out the playspace


            if ( eX > 4 )
            {
                eX = 4;
            }
            if ( eX < 0 )
            {
                eX = 0;
            }

            if ( eY > 4 )
            {
                eY = 4;
            }
            if ( eY < 0 )
            {
                eY = 0;
            }



            for (int y = 0; y < 5; y++)
            {
                row.Clear();

                for (int x = 0; x < 5; x++)
                {
                    if (x == xPos && y == yPos)
                    {
                        row.Add(":red_square:");
                    }else if (eX == x && eY == y)
                    {
                        row.Add(":green_square:");
                    }else
                    {
                        row.Add(":blue_square:");
                    }
                }
                await ctx.Channel.SendMessageAsync(string.Join("", row));
            }

            await ctx.Channel.SendMessageAsync($"xPos: {xPos}");
            await ctx.Channel.SendMessageAsync($"yPos: {yPos}");
            await ctx.Channel.SendMessageAsync($"EnemyX: {eX}");
            await ctx.Channel.SendMessageAsync($"EnemyY: {eY}");
        }
    }
}
