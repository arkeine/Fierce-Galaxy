using FierceGalaxyInterface.ConnexionModule;
using System;
using System.Collections.Generic;

namespace FierceGalaxyServer.ConnexionModule
{
    public class TokenManager : ITokenManager
    {
        //======================================================
        // Field
        //======================================================

        //Link timestamp and player
        private DoubleDictionary<IReadOnlyPlayer, Int64> mapPlayerToken = new DoubleDictionary<IReadOnlyPlayer, Int64>();
        //Timestamp of the tokens
        private IDictionary<IReadOnlyPlayer, DateTime> mapValidityTime = new Dictionary<IReadOnlyPlayer, DateTime>();
        //Validity time range of a new token
        private TimeSpan maxGap = new TimeSpan(0, 0, 30);

        //======================================================
        // Singleton
        //======================================================

        private static TokenManager singleton;

        public static TokenManager GetInstance()
        {
            if (singleton == null)
            {
                singleton = new TokenManager();
            }

            return singleton;
        }

        private TokenManager()
        {
            // Nothing
        }

        //======================================================
        // Override
        //======================================================

        public bool ConsumeToken(long token)
        {
            bool result = false;

            if (mapPlayerToken.Contains(token))
            {
                IReadOnlyPlayer player = mapPlayerToken.GetOther(token);
                
                if ((mapValidityTime[player] - DateTime.Now) <= maxGap)
                {
                    result = true;
                }

                mapPlayerToken.Remove(player);
                mapValidityTime.Remove(player);
            }

            return result;
        }

        public long GenerateToken(IPlayer player)
        {
            mapPlayerToken.Remove(player);

            bool tokenValid = false;
            long token;

            do
            {
                token = GenerateRandomToken();
                tokenValid = mapPlayerToken.Add(player, token);
            } while (!tokenValid);

            mapValidityTime[player] = DateTime.Now;

            return token;
        }

        public void RemoveToken(IPlayer player)
        {
            mapPlayerToken.Remove(player);
            mapValidityTime.Remove(player);
        }

        //======================================================
        // Private
        //======================================================

        long GenerateRandomToken()
        {
            return LongRandom(long.MinValue, long.MaxValue, new Random());
        }

        long LongRandom(long min, long max, Random rand)
        {
            long result = rand.Next((Int32)(min >> 32), (Int32)(max >> 32));
            result = (result << 32);
            result = result | (long)rand.Next((Int32)min, (Int32)max);
            return result;
        }        
    }
}