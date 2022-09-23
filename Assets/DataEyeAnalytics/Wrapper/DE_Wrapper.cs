using System;
using System.Collections.Generic;
using DataEyeAnalytics.Utils;
using UnityEngine;

namespace DataEyeAnalytics.Wrapper
{
    public partial class DataEyeAnalyticsWrapper
    {
#if (!(UNITY_EDITOR || UNITY_IOS || UNITY_ANDROID|| UNITY_STANDALONE))
        private string uniqueId;
        private void init()
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - Thanks for using DataEyeAnalytics SDK for tracking data.");
        }
        private static void enable_log(bool enableLog)
        {
            DE_Log.d("TA.Wrapper - calling enable_log with enableLog: " + enableLog);
        }

        public static void setVersionInfo(string libName, string version) {

        }

        private void identify(string uniqueId)
        {
            this.uniqueId = uniqueId;
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling Identify with uniqueId: " + uniqueId);
        }
        private string getDistinctId()
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling GetDistinctId with return value: " + this.uniqueId);
            return this.uniqueId;
        }

        private void login(string accountId)
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling Login with accountId: " + accountId);
        }

        private void logout()
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling Logout");
        }

        private void track(string eventName, string properties)
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling track with eventName: " + eventName + ", " +
                "properties: " + properties);
        }

        private void track(string eventName, string properties, DateTime datetime)
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling track with eventName: " + eventName + ", " +
                "properties: " + properties + ", " +
                "dateTime: " + datetime.ToString());
        }

        private void track(DataEyeAnalyticsEvent analyticsEvent)
        {
                DE_Log.d("TA.Wrapper(" + token.appid + ") - calling track with eventName: " + analyticsEvent.EventName + ", " +
                "properties: " + getFinalEventProperties(analyticsEvent.Properties));

        }

        private void setSuperProperties(string superProperties)
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling setSuperProperties with superProperties: " + DE_MiniJSON.Serialize(superProperties));
        }

        private void unsetSuperProperty(string superPropertyName)
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling unsetSuperProperties with superPropertyName: " + superPropertyName);

        }
        private void clearSuperProperty()
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling clearSuperProperties");
        }

        private Dictionary<string, object> getSuperProperties()
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling getSuperProperties");
            return null;
        }
        private void timeEvent(string eventName)
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling timeEvent with eventName: " + eventName);
        }

        private void userSet(string properties)
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling userSet with properties: " + DE_MiniJSON.Serialize(properties));
        }

        private void userSet(string properties, DateTime dateTime)
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling userSet with properties: " + DE_MiniJSON.Serialize(properties)
                + ", dateTime: " + dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }
        private void userSetOnce(string properties)
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling userSetOnce with properties: " + DE_MiniJSON.Serialize(properties));
        }

        private void userSetOnce(string properties, DateTime dateTime)
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling userSetOnce with properties: " + DE_MiniJSON.Serialize(properties)
                + ", dateTime: " + dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void userUnset(List<string> properties)
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling userUnset with properties: " + string.Join(", ", properties.ToArray()));
        }

        private void userUnset(List<string> properties, DateTime dateTime)
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling userUnset with properties: " + string.Join(", ", properties.ToArray())
                + ", dateTime: " + dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void userAdd(string properties)
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling userAdd with properties: " + DE_MiniJSON.Serialize(properties));
        }

        private void userAdd(string properties, DateTime dateTime)
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling userAdd with properties: " + DE_MiniJSON.Serialize(properties)
                 + ", dateTime: " + dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void userAppend(string properties)
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling userAppend with properties: " + DE_MiniJSON.Serialize(properties));
        }

        private void userAppend(string properties, DateTime dateTime)
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling userAppend with properties: " + DE_MiniJSON.Serialize(properties)
                + ", dateTime: " + dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void userDelete()
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling userDelete");
        }

        private void userDelete(DateTime dateTime)
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling userDelete"  + ", dateTime: " + dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void flush()
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling flush.");
        }

        private void enableAutoTrack(AUTO_TRACK_EVENTS events)
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling enableAutoTrack: " + events.ToString());
        }
        private void setNetworkType(DataEyeAnalyticsAPI.NetworkType networkType)
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling setNetworkType with networkType: " + (int)networkType);
        }

        private string getDeviceId() {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling getDeviceId()");
            return "editor device id";
        }

        private void optOutTracking()
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling optOutTracking()");
        }

        private void optOutTrackingAndDeleteUser()
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling optOutTrackingAndDeleteUser()");
        }

        private void optInTracking()
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling optInTracking()");
        }

        private void enableTracking(bool enabled)
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling enableTracking() with enabled: " + enabled);
        }

        private DataEyeAnalyticsWrapper createLightInstance(DataEyeAnalyticsAPI.Token delegateToken)
        {
            DE_Log.d("TA.Wrapper(" + token.appid + ") - calling createLightInstance()");
            return new DataEyeAnalyticsWrapper(delegateToken, false);
        }

        private string getTimeString(DateTime dateTime) {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        private static void calibrateTime(long timestamp)
        {
            DE_Log.d("TA.Wrapper: - calling calibrateTime() with: " + timestamp);
        }

        private static void calibrateTimeWithNtp(string ntpServer)
        {
            DE_Log.d("TA.Wrapper: - calling calibrateTimeWithNtp() with: " + ntpServer);
        }

#endif
        public readonly DataEyeAnalyticsAPI.Token token;
        private IDynamicSuperProperties dynamicSuperProperties;

        private static System.Random rnd = new System.Random();

        private string serilize<T>(Dictionary<string, T> data) {
            return DE_MiniJSON.Serialize(data, getTimeString);
        }

        public DataEyeAnalyticsWrapper(DataEyeAnalyticsAPI.Token token, bool initRequired = true)
        {
            this.token = token;
            if (initRequired) init();
        }

        public static void EnableLog(bool enableLog)
        {
            enable_log(enableLog);
        }

        public static void SetVersionInfo(string version)
        {
            setVersionInfo("Unity", version);
        }

        public void Identify(string uniqueId)
        {
            identify(uniqueId);
        }

        public string GetDistinctId()
        {
            return getDistinctId();
        }

        public void Login(string accountId)
        {
            login(accountId);
        }

        public void Logout()
        {
            logout();
        }

        public void EnableAutoTrack(AUTO_TRACK_EVENTS events)
        {
            enableAutoTrack(events);
        }

        private string getFinalEventProperties(Dictionary<string, object> properties)
        {
            DE_PropertiesChecker.CheckProperties(properties);

            if (null != dynamicSuperProperties)
            {
                Dictionary<string, object> finalProperties = new Dictionary<string, object>();
                DE_PropertiesChecker.MergeProperties(dynamicSuperProperties.GetDynamicSuperProperties(), finalProperties);
                DE_PropertiesChecker.MergeProperties(properties, finalProperties);
                return serilize(finalProperties);
            }
            else
            {
                return serilize(properties);
            }

        }
        public void Track(string eventName, Dictionary<string, object> properties)
        {
            DE_PropertiesChecker.CheckString(eventName);
            track(eventName, getFinalEventProperties(properties));
        }

        public void Track(string eventName, Dictionary<string, object> properties, DateTime datetime)
        {
            DE_PropertiesChecker.CheckString(eventName);
            track(eventName, getFinalEventProperties(properties), datetime);
        }

        public void Track(DataEyeAnalyticsEvent taEvent)
        {
            if (null == taEvent || null == taEvent.EventType)
            {
                DE_Log.w("Ignoring invalid TA event");
                return;
            }

            if (taEvent.EventTime == null)
            {
                DE_Log.w("ppp null...");
            }
            DE_PropertiesChecker.CheckString(taEvent.EventName);
            DE_PropertiesChecker.CheckProperties(taEvent.Properties);
            track(taEvent);
        }

        public void SetSuperProperties(Dictionary<string, object> superProperties)
        {
            DE_PropertiesChecker.CheckProperties(superProperties);
            setSuperProperties(serilize(superProperties));
        }

        public void UnsetSuperProperty(string superPropertyName)
        {
            DE_PropertiesChecker.CheckString(superPropertyName);
            unsetSuperProperty(superPropertyName);
        }

        public void ClearSuperProperty()
        {
            clearSuperProperty();
        }


        public void TimeEvent(string eventName)
        {
            DE_PropertiesChecker.CheckString(eventName);
            timeEvent(eventName);
        }

        public Dictionary<string, object> GetSuperProperties()
        {
            return getSuperProperties();
        }

        public void UserSet(Dictionary<string, object> properties)
        {
            DE_PropertiesChecker.CheckProperties(properties);
            userSet(serilize(properties));
        }

        public void UserSet(Dictionary<string, object> properties, DateTime dateTime)
        {
            DE_PropertiesChecker.CheckProperties(properties);
            userSet(serilize(properties), dateTime);
        }

        public void UserSetOnce(Dictionary<string, object> properties)
        {
            DE_PropertiesChecker.CheckProperties(properties);
            userSetOnce(serilize(properties));
        }

        public void UserSetOnce(Dictionary<string, object> properties, DateTime dateTime)
        {
            DE_PropertiesChecker.CheckProperties(properties);
            userSetOnce(serilize(properties), dateTime);
        }

        public void UserUnset(List<string> properties)
        {
            DE_PropertiesChecker.CheckProperteis(properties);
            userUnset(properties);
        }

        public void UserUnset(List<string> properties, DateTime dateTime)
        {
            DE_PropertiesChecker.CheckProperteis(properties);
            userUnset(properties, dateTime);
        }

        public void UserAdd(Dictionary<string, object> properties)
        {
            DE_PropertiesChecker.CheckProperties(properties);
            userAdd(serilize(properties));
        }

        public void UserAdd(Dictionary<string, object> properties, DateTime dateTime)
        {
            DE_PropertiesChecker.CheckProperties(properties);
            userAdd(serilize(properties), dateTime);
        }

        public void UserAppend(Dictionary<string, object> properties)
        {
            DE_PropertiesChecker.CheckProperties(properties);
            userAppend(serilize(properties));
        }

        public void UserAppend(Dictionary<string, object> properties, DateTime dateTime)
        {
            DE_PropertiesChecker.CheckProperties(properties);
            userAppend(serilize(properties), dateTime);
        }

        public void UserDelete()
        {
            userDelete();
        }

        public void UserDelete(DateTime dateTime)
        {
            userDelete(dateTime);
        }

        public void Flush()
        {
            flush();
        }

        public void SetNetworkType(DataEyeAnalyticsAPI.NetworkType networkType)
        {
            setNetworkType(networkType);
        }

        public string GetDeviceId()
        {
            return getDeviceId();
        }

        public void SetDynamicSuperProperties(IDynamicSuperProperties dynamicSuperProperties)
        {
            if (!DE_PropertiesChecker.CheckProperties(dynamicSuperProperties.GetDynamicSuperProperties()))
            {
                DE_Log.d("TA.Wrapper(" + token.appid + ") - Cannot set dynamic super properties due to invalid properties.");
            }
            this.dynamicSuperProperties = dynamicSuperProperties;
        }

        public void OptOutTracking()
        {
            optOutTracking();
        }

        public void OptOutTrackingAndDeleteUser()
        {
            optOutTrackingAndDeleteUser();
        }

        public void OptInTracking()
        {
            optInTracking();
        }

        public void EnableTracking(bool enabled)
        {
            enableTracking(enabled);
        }

        public DataEyeAnalyticsWrapper CreateLightInstance()
        {
            return createLightInstance(new DataEyeAnalyticsAPI.Token(rnd.Next().ToString(), token.serverUrl, token.mode, token.timeZone, token.reyunAppID, token.timeZoneId));
        }

        internal string GetAppId()
        {
            return token.appid;
        }

        public static void CalibrateTime(long timestamp)
        {
            calibrateTime(timestamp);
        }

        public static void CalibrateTimeWithNtp(string ntpServer)
        {
            calibrateTimeWithNtp(ntpServer);
        }
    }
}

