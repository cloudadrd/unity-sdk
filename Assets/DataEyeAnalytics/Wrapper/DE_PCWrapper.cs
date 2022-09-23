
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DataEyeAnalytics.Utils;
using UnityEngine;


namespace DataEyeAnalytics.Wrapper
{
    public partial class DataEyeAnalyticsWrapper
    {
#if  (UNITY_STANDALONE || UNITY_EDITOR)
        private void init()
        {

        }

        private void identify(string uniqueId)
        {

        }

        private string getDistinctId()
        {
            return null;
        }

        private void login(string accountId)
        {

        }

        private void logout()
        {

        }

        private void flush()
        {
           
        }

        private static void setVersionInfo(string lib_name, string lib_version) {

        }

        private void track(DataEyeAnalyticsEvent taEvent)
        {

        }

        private void track(string eventName, string properties)
        {  

        }

        private void track(string eventName, string properties, DateTime dateTime)
        {

        }

        private void setSuperProperties(string superProperties)
        {

        }

        private void unsetSuperProperty(string superPropertyName)
        {

        }

        private void clearSuperProperty()
        {

        }

        private Dictionary<string, object> getSuperProperties()
        {
            return null;
        }

        private void timeEvent(string eventName)
        {

        }

        private void userSet(string properties)
        {

        }

        private void userSet(string properties, DateTime dateTime)
        {

        }

        private void userUnset(List<string> properties)
        {

        }

        private void userUnset(List<string> properties, DateTime dateTime)
        {

        }

        private void userSetOnce(string properties)
        {

        }

        private void userSetOnce(string properties, DateTime dateTime)
        {

        }

        private void userAdd(string properties)
        {

        }

        private void userAdd(string properties, DateTime dateTime)
        {

        }

        private void userDelete()
        {

        }

        private void userDelete(DateTime dateTime)
        {
 
        }

        private void userAppend(string properties)
        {

        }

        private void userAppend(string properties, DateTime dateTime)
        {

        }

        private void setNetworkType(DataEyeAnalyticsAPI.NetworkType networkType)
        {
            
        }

        private string getDeviceId() 
        {
            return null;
        }

        private void optOutTracking()
        {

        }

        private void optOutTrackingAndDeleteUser()
        {

        }

        private void optInTracking()
        {

        }

        private void enableTracking(bool enabled)
        {

        }

        private DataEyeAnalyticsWrapper createLightInstance(DataEyeAnalyticsAPI.Token delegateToken)
        {
            return null;
        }

        private string getTimeString(DateTime dateTime)
        {
            return null;                  
        }

        private void enableAutoTrack(AUTO_TRACK_EVENTS autoTrackEvents)
        {

        }
        private static void enable_log(bool enableLog)
        {

        }
        private static void calibrateTime(long timestamp)
        {

        }

        private static void calibrateTimeWithNtp(string ntpServer)
        {
           
        }
#endif
    }
}