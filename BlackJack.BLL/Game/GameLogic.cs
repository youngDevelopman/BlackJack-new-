﻿using BlackJack.BLL.Interfaces;
using BlackJack.BLL.ViewModels;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BlackJack.BLL.Game
{
    public class GameLogic : IGameLogic
    {
        static Random random;

        private IUnitOfWork _database { get; set; }

        public GameLogic(IUnitOfWork database)
        {
            _database = database;
        }


        static GameLogic()
        {
            random = new Random();
        }

        // Gives two cards for each player
        public  void GiveCardsOnStart()
        {
            List<Player> playersArray = _database.Players.GetAll().ToList();
            List<Card> cardsList = _database.Cards.GetAll().ToList();

            GiveCardsToAllPlayers();
            GiveCardsToAllPlayers();

        }

        private  bool CheckUniqueCardId(int id)
        {
            List<int> cardIds = _database.Players.GetCardsIdInDeck().ToList();
            bool isUnique = !cardIds.Contains(id);

            return isUnique;
        }

        // Saves game history into GameHistories table
        public void SaveGameHistory(List<PlayerViewModel> winnerList, int roundId)
        {
            
            foreach (var winner in winnerList)
            {
                var winnerCards = _database.Players.GetAllCardsFromPlayer(winner.Id) as List<Card>;
                var currentWinner = new GameHistory()
                {
                    WinnerId = winner.Id,
                    RoundId = roundId,
                    WinnerName = winner.Name,
                    WinnerScore = winner.Count,
                    Date = DateTime.Now,
                    Cards = winnerCards
                };

                _database.GameHistories.Create(currentWinner);
            }

        }

        // Gives cards to all players using specified conditions
        public  void GiveCardsToAllPlayers()
        {
            List<Player> playersArray = _database.Players.GetAll().ToList();
            List<Card> cardsList = _database.Cards.GetAll().ToList();

            for (int i = 0; i < playersArray.Count; i++)
            {
                Player currentPlayer = playersArray[i];
                int currentPlayerCount = _database.Players.GetAllCardsFromPlayer(currentPlayer.Id).Sum(c => c.Value);

                if ((currentPlayer.Status == "Bot" || currentPlayer.Status == "Dealer")
                    && currentPlayerCount <= 17)
                {
                    GiveCards(currentPlayer, cardsList);
                    Thread.Sleep(100);
                }

                else if(currentPlayer.Status == "Player" && currentPlayerCount < 21)
                {
                    GiveCards(currentPlayer, cardsList);
                    Thread.Sleep(100);

                }

            }
        }

        // Gives list of cards to one specified player
        private void GiveCards(Player player, List<Card> cardsList)
        {

            bool isNotOver = true;

            do
            {

                int randomCardId = random.Next(1, cardsList.Count);

                if (CheckUniqueCardId(randomCardId))
                {
                    _database.Players.AddCard(player, cardsList[randomCardId - 1]);
                    isNotOver = false;
                }

            } while (isNotOver);
        }

       
    }
}
