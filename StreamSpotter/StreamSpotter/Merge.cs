using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter
{
    public class Merge
    {
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

        RootObject deleteResult(RootObject ro, int index)
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
            return r1;
        }
    }
}
