using FierceGalaxyInterface.ConnexionModule;
using System;

namespace FierceGalaxyServer.ConnexionModule
{
    public class TokenManager : ITokenManager
    {
        //======================================================
        // Field
        //======================================================

        private TokenDictionary mapPlayerToken = new TokenDictionary();
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
                IPlayer p = mapPlayerToken.GetPlayer(token);
                
                if ((mapPlayerToken.GetTimestamp(p) - DateTime.Now) <= maxGap)
                {
                    result = true;
                }

                mapPlayerToken.RemoveToken(p);
            }

            return result;
        }

        public long GenerateToken(IPlayer player)
        {
            mapPlayerToken.RemoveToken(player);

            bool tokenValid = false;
            long token;

            do
            {
                token = GenerateRandomToken();
                tokenValid = mapPlayerToken.AddToken(player, token);
            } while (!tokenValid);

            return token;
        }

        public void RemoveToken(IPlayer player)
        {
            mapPlayerToken.RemoveToken(player);
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