﻿using System;
using System.Diagnostics;
using System.Reflection;
using PoGo.NecroBot.Logic.Logging;

namespace PoGo.NecroBot.Logic.Utils
{
    class ErrorHandler
    {
        /// <summary>
        /// Alerts that a fatal error has occurred, displaying a message and exiting the application
        /// </summary>
        /// <param name="strMessage">Optional message to display - Leave NULL to exclude message</param>
        /// <param name="timeout">The total seconds the messag will display before shutting down</param>
        public static void ThrowFatalError( string strMessage, int timeout, LogLevel level, bool boolRestart = false )
        {
            if( strMessage != null)
                Logger.Write( strMessage, level );

            Logger.Write( "Ending Application... ", LogLevel.Error );

            for( int i = timeout; i > 0; i-- )
            {
                Logger.Write( "\b" + i, LogLevel.Error );
                System.Threading.Thread.Sleep( 1000 );
            }

            if( boolRestart )
                Process.Start( Assembly.GetEntryAssembly().Location );

            Environment.Exit( -1 );
        }
    }
}
