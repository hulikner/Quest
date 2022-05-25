using System;
using System.Collections.Generic;

namespace Quest
{
    public class Hat
        {
            public int ShininessLevel { get;set; }

            
            public string ShininessDescription(int ShininessLevel)
            {
                if(ShininessLevel < 2)
                {
                    return "dull";
                }
                else if(ShininessLevel > 1 && ShininessLevel < 6)
                {
                    return "noticable";

                }
                else if(ShininessLevel > 5 && ShininessLevel < 10)
                {
                    return "bright";

                }
                else if(ShininessLevel > 10)
                {
                    return "blinding";
                }
                else 
                {
                    return "no hat";
                }
            }
            
        }
}    