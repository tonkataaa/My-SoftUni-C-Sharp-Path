﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data
{
	public class FootballBettingContext : DbContext
	{
        public FootballBettingContext()
        {
            
        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }
        
        public DbSet<Bet> Bets { get; set; }
		public DbSet<Color> Colors { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<Game> Games { get; set; }
		public DbSet<Player> Players { get; set; }
		public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
		public DbSet<Position> Positions { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<Town> Towns { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=.;Database=FootballBetting;Integrated Security=true");
			}

			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Team>(x =>
			{
				x.HasOne(x => x.PrimaryKitColor)
				.WithMany(x => x.PrimaryKitTeams)
				.HasForeignKey(x => x.PrimaryKitColorId);

				x.HasOne(x => x.SecondaryKitColor)
				.WithMany(x => x.SecondaryKitTeams)
				.HasForeignKey(x => x.SecondaryKitColorId);
			});

			modelBuilder.Entity<Game>(x =>
			{
				x.HasOne(x => x.HomeTeam)
				.WithMany(x => x.HomeGames)
				.HasForeignKey(x => x.HomeTeamId);

				x.HasOne(x => x.AwayTeam)
				.WithMany(x => x.AwayGames)
				.HasForeignKey(x => x.AwayTeamId);
			});

			modelBuilder.Entity<PlayerStatistic>(x =>
			{
				x.HasKey(x => new { x.PlayerId, x.GameId });
			});

			base.OnModelCreating(modelBuilder);
		}
	}
}
