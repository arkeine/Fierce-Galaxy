using FierceGalaxyInterface.ConnexionModule;
using System;
using System.Collections.Generic;

namespace FierceGalaxyServer.ConnexionModule
{
    /// <summary>
    /// Manage the correspondence between the player, his token and the life time of the token
    /// </summary>
    public class TokenDictionary
    {
        //======================================================
        // Field
        //======================================================

        //This two dictionary work like one where keys and values are both unique
        private IDictionary<Int64, IPlayer> mapTokenToPlayer = new Dictionary<Int64, IPlayer>();
        private IDictionary<IPlayer, Int64> mapPlayerToToken = new Dictionary<IPlayer, Int64>();
        //Timestamp of the tokens
        private IDictionary<IPlayer, DateTime> mapPlayerToTime = new Dictionary<IPlayer, DateTime>();

        //======================================================
        // Accessor/Mutator
        //======================================================

        public bool AddToken(IPlayer player, Int64 token)
        {
            if (!mapPlayerToToken.ContainsKey(player) &&
                !mapTokenToPlayer.ContainsKey(token))
            {
                mapPlayerToToken[player] = token;
                mapTokenToPlayer[token] = player;
                mapPlayerToTime[player] = DateTime.Now;

                return true;
            }
            return false;
        }

        public void RemoveToken(IPlayer player)
        {
            mapTokenToPlayer.Remove(mapPlayerToToken[player]);
            mapPlayerToToken.Remove(player);
            mapPlayerToTime.Remove(player);
        }

        public DateTime GetTimestamp(IPlayer player)
        {
            return mapPlayerToTime[player];
        }

        public DateTime GetTimestamp(long token)
        {
            return mapPlayerToTime[GetPlayer(token)];
        }

        public IPlayer GetPlayer(long token)
        {
            return mapTokenToPlayer[token];
        }

        public long GetToken(IPlayer player)
        {
            return mapPlayerToToken[player];
        }

        public bool Contains(IPlayer player)
        {
            return mapPlayerToToken.ContainsKey(player);
        }

        public bool Contains(long token)
        {
            return mapTokenToPlayer.ContainsKey(token);
        }        
    }
}