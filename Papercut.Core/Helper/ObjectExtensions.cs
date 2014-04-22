/*  
 * Papercut
 *
 *  Copyright � 2008 - 2012 Ken Robertson
 *  Copyright � 2013 - 2014 Jaben Cargman
 *  
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *  
 *  http://www.apache.org/licenses/LICENSE-2.0
 *  
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 *  
 */

namespace Papercut.Core
{
    using System;
    using System.Collections.Generic;

    public static class ObjectExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        ///     If value is not null, calls continueFunc with value, else, returns default(TOut).
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="value"></param>
        /// <param name="continueFunc"></param>
        /// <returns></returns>
        public static TOut IfNotNull<TIn, TOut>(this TIn value, Func<TIn, TOut> continueFunc)
        {
            return value.IsDefault() ? default(TOut) : continueFunc(value);
        }

        /// <summary>
        ///     Compares value to default(TIn) and return true if it's default.
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDefault<TIn>(this TIn value)
        {
            // from the master, J. Skeet:
            return EqualityComparer<TIn>.Default.Equals(value, default(TIn));
        }

        /// <summary>
        ///     Converts to an IEnumerable'T if obj is not default.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IEnumerable<T> ToEnumerable<T>(this T obj)
        {
            if (!obj.IsDefault())
            {
                yield return obj;
            }

            yield break;
        }

        #endregion
    }
}