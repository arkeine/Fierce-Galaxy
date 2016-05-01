using FierceGalaxyInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FierceGalaxyServer
{
    /// <summary>
    /// Manage the temporary connection token
    /// </summary>
    public class TokenManager : ITokenManager
    {
        //======================================================
        // Field
        //======================================================

        //Link timestamp and player
        private DoubleDictionary<IReadOnlyPlayer, Int64> dicPlayerToken = new DoubleDictionary<IReadOnlyPlayer, Int64>();
        //Timestamp of the tokens
        private IDictionary<IReadOnlyPlayer, DateTime> dicValidityTime = new Dictionary<IReadOnlyPlayer, DateTime>();
        //Validity time range of a new token
        private TimeSpan tokenValidityTime;

        //======================================================
        // Constructor
        //======================================================

        public TokenManager() : this(new TimeSpan(0, 0, 30)) { }

        public TokenManager(TimeSpan tokenValidityTime)
        {
            this.tokenValidityTime = tokenValidityTime;
        }

        //======================================================
        // Override
        //======================================================

        public bool IsValid(long token)
        {
            bool result = false;

            if (dicPlayerToken.Contains(token))
            {
                IReadOnlyPlayer player = dicPlayerToken.GetOther(token);
                
                if (IsTimeValid(dicValidityTime[player]))
                {
                    result = true;
                }

                RemoveToken(player);
            }

            return result;
        }

        public long GenerateToken(IReadOnlyPlayer player)
        {
            dicPlayerToken.Remove(player);

            bool tokenValid = false;
            long token;

            do
            {
                token = GenerateRandomToken();
                tokenValid = dicPlayerToken.Add(player, token);
            } while (!tokenValid);

            dicValidityTime[player] = DateTime.Now;

            return token;
        }

        public void RemoveToken(IReadOnlyPlayer player)
        {
            dicPlayerToken.Remove(player);
            dicValidityTime.Remove(player);
        }

        public IReadOnlyPlayer GetPlayer(long token)
        {
            if(IsValid(token))
            {
                return dicPlayerToken.GetOther(token);
            }
            return null;
        }

        public void InvalidateToken(long token)
        {
            var p = GetPlayer(token);

            if(p != null)
            {
                dicPlayerToken.Remove(p);
                dicValidityTime.Remove(p);
            }
        }

        //======================================================
        // public
        //======================================================

        public void CleanToken()
        {
            var list = dicValidityTime.ToList();

            foreach (var v in list)
            {
                if(!IsTimeValid(v.Value))
                {
                    dicValidityTime.Remove(v.Key);
                    dicPlayerToken.Remove(v.Key);
                }
            }
        }

        //======================================================
        // Private
        //======================================================

        private bool IsTimeValid(DateTime t)
        {
            return ((t - DateTime.Now) <= tokenValidityTime);
        }

        private long GenerateRandomToken()
        {
            return LongRandom(long.MinValue, long.MaxValue, new Random());
        }

        private long LongRandom(long min, long max, Random rand)
        {
            long result = rand.Next((Int32)(min >> 32), (Int32)(max >> 32));
            result = (result << 32);
            result = result | (long)rand.Next((Int32)min, (Int32)max);
            return result;
        }
    }
}