using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 12:59:59
* Class Version       :    v1.0.0.0
* Class Description   :    
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    public static class Ensure
    {
        public static void NotNull<T>(T argument,string argumentName) where T:class
        {
            if (argument == null)
                throw new ArgumentNullException(argumentName + " should not be null.");
        }

        public static void NotNullOrEmpty(string argument, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(argument))
                throw new ArgumentNullException(argument, argumentName + " should not be null or empty.");
        }
    }
}
