using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter
{
        /*******************************************************************************************************
         * Merge is used to combine two different RootObject classes (list of Results). This includes combining
         * duplicate Results from different services into one Result.
         *******************************************************************************************************/
    public class Merge
    {
        /*******************************************************************************************************
         * Merge two different root objects together
         * PARAMS: RootObject ro1 
         *         RootObject ro2
         * RETURN: The result of combining both of the parameter RootObjects
         *******************************************************************************************************/
        public RootObject mergeLists(RootObject ro1, RootObject ro2)
        {
            int length1 = ro1.results.Length;
            int length2 = ro2.results.Length;
            for(int i = 0; i < length1; i++)
            {
                for(int j = 0; j < length2; j++)
                {
                    if(ro1.results[i].imdbID == ro2.results[j].imdbID)
                    {
                        ro1.results[i] = combineStreamingInfo(ro1.results[i], ro2.results[j]);
                        ro2 = deleteResult(ro2, j);
                        length2 = ro2.results.Length;
                    }
                }
            }
            return combineRoots(ro1, ro2);

        }
        /*******************************************************************************************************
         * Deletes a result from the RootObject given at the given index
         * PARAMS: RootObject ro, RootObject to be deleted from
         *         int index, index of the Result to be deleted
         * RETURN: RootObject which is the outcome of deleting the Result
         *******************************************************************************************************/
        private RootObject deleteResult(RootObject ro, int index)
        {
            int length = ro.results.Length;
            RootObject finish = new RootObject();
            finish.results = new Result[length - 1];
            if(index < length - 1)
            {
                for(int i = 0; i < index; i++)
                {
                    finish.results[i] = ro.results[i];
                }
                for(int i = index; i < length-1; i++)
                {
                    finish.results[i] = ro.results[i + 1];
                }
            }
            else
            {
                for(int i = 0; i < length-1; i++)
                {
                    finish.results[i] = ro.results[i];
                }
            }
            return finish;
        }
        /*******************************************************************************************************
         * Combines both RootObjects into one big RootObject
         * PARAMS: RootObject ro1, RootObject which will be at the front of the new RootObject
         *         RootObject ro2, RootObject which will be at the back of the new RootObject
         * RETURN: RootObject which contains all of the Results in both parameter RootObjects
         *******************************************************************************************************/
        RootObject combineRoots(RootObject ro1, RootObject ro2)
        {
            int length1 = ro1.results.Length;
            int length2 = ro2.results.Length;
            int add = ro1.results.Length;
            RootObject temp = new RootObject();
            temp.results = new Result[length1 + length2];
            for (int i = 0; i < length1; i++)
            {
                temp.results[i] = ro1.results[i];
            }

            for(int i = 0; i < length2; i++)
            {
                temp.results[add] = ro2.results[i];
                add++;
            }
            return temp;
        }
        /*******************************************************************************************************
         * Combines the StreamingInfo attributes of two given Results.
         * PARAMS: Result r1
         *         Result r2
         * RETURN: Result that has all StreamingInfo elements from both parameter Results
         *******************************************************************************************************/
        Result combineStreamingInfo(Result r1, Result r2)
        {
            if(r1.streamingInfo.netflix == null && r2.streamingInfo.netflix != null)
            {
                r1.streamingInfo.netflix = r2.streamingInfo.netflix;
            }
            if(r1.streamingInfo.disney == null && r2.streamingInfo.disney != null)
            {
                r1.streamingInfo.disney = r2.streamingInfo.disney;
            }
            if (r1.streamingInfo.hulu == null && r2.streamingInfo.hulu != null)
            {
                r1.streamingInfo.hulu = r2.streamingInfo.hulu;
            }
            if (r1.streamingInfo.prime == null && r2.streamingInfo.prime != null)
            {
                r1.streamingInfo.prime = r2.streamingInfo.prime;
            }
            return r1;
        }
    }
}
