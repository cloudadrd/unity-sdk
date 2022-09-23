using UnityEngine;
using DataEyeAnalytics;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class DEExample : MonoBehaviour, IDynamicSuperProperties
{


    public GUISkin skin;
    private Vector2 scrollPosition = Vector2.zero;
    //private static Color MainColor = new Color(0, 0,0);
    private static Color MainColor = new Color(84f / 255, 116f / 255, 241f / 255);
    private static Color TextColor = new Color(153f / 255, 153f / 255, 153f / 255);
    static int Margin = 40;
    static int Height = 80;
    static float ContainerWidth = Screen.width - 2 * Margin;
    // 动态公共属性接口
    public Dictionary<string, object> GetDynamicSuperProperties()
    {
       return new Dictionary<string, object>() {
           {"DynamicProperty", DateTime.Now}
       };
    }
    void Awake()
    {
    }

    void OnGUI() {
        GUILayout.BeginArea(new Rect(Margin, Screen.height * 0.15f, Screen.width-2*Margin, Screen.height));
        scrollPosition = GUILayout.BeginScrollView(new Vector2(0, 0), GUILayout.Width(Screen.width - 2 * Margin), GUILayout.Height(Screen.height - 100));
        GUIStyle style = GUI.skin.label;
        style.fontSize = 25;
        GUILayout.Label("设置用户ID",style);

        GUIStyle buttonStyle = GUI.skin.button;
        buttonStyle.fontSize = 20;
        GUILayout.BeginHorizontal(GUI.skin.box,GUILayout.Height(Height));
        if (GUILayout.Button("设置账号ID", GUILayout.Height(Height)))
        {
            DataEyeAnalyticsAPI.Login("TA");
        }

        GUILayout.Space(20);
        if (GUILayout.Button("设置访客ID", GUILayout.Height(Height)))
        {
            DataEyeAnalyticsAPI.Identify("TA_Distinct1");
            
        }
        GUILayout.Space(20);
        if (GUILayout.Button("清除账号ID", GUILayout.Height(Height)))
        {
            DataEyeAnalyticsAPI.Logout();
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(20);
        GUILayout.Label("上传事件", GUI.skin.label);
        GUILayout.BeginHorizontal(GUI.skin.textArea, GUILayout.Height(Height));
        if (GUILayout.Button("普通事件", GUILayout.Height(Height)))
        {
            Dictionary<string, object> properties = new Dictionary<string, object>(){
                {"KEY_STRING", "B1"},
                {"KEY_BOOL", true},
                {"KEY_NUMBER", 50.65},
                {"Key_Test","好的"}
            };
            DataEyeAnalyticsAPI.Track("TA",properties);
        }
        GUILayout.Space(20);
        if (GUILayout.Button("首次事件", GUILayout.Height(Height)))
        {
            Dictionary<string, object> properties = new Dictionary<string, object>(){
                {"KEY_STRING", "B1"},
                {"KEY_BOOL", true},
                {"KEY_NUMBER", 50.65}
            };
            TDFirstEvent firstEvent = new TDFirstEvent("DEVICE_FIRST", properties);
            DataEyeAnalyticsAPI.Track(firstEvent);
        }
        GUILayout.Space(20);
        if (GUILayout.Button("可更新事件", GUILayout.Height(Height)))
        {
            // 示例： 上报可被更新的事件，假设事件名为 UPDATABLE_EVENT
            TDUpdatableEvent updatableEvent = new TDUpdatableEvent("UPDATABLE_EVENT",
                new Dictionary<string, object>{
                    {"status", 3},
                    
                    {"price", 100}},
                "test_event_id");
            DataEyeAnalyticsAPI.Track(updatableEvent);

        }

        GUILayout.Space(20);
        if (GUILayout.Button("可重写事件", GUILayout.Height(Height)))
        {
            TDOverWritableEvent overWritableEvent = new TDOverWritableEvent("OVERWRITABLE_EVENT",
                new Dictionary<string, object>{
                    {"status", 3},
                    {"super1",100},
                    {"price", 100}},
                "test_event_id");
            DataEyeAnalyticsAPI.Track(overWritableEvent);
        }

        GUILayout.Space(20);
        if (GUILayout.Button("记录事件时长", GUILayout.Height(Height)))
        {
            DataEyeAnalyticsAPI.TimeEvent("TATimeEvent");
            Invoke("TrackTimeEvent", 3);

        }

        GUILayout.Space(20);
        if (GUILayout.Button("自定义事件发生时间", GUILayout.Height(Height)))
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties["proper1"] = 1;
            properties["proper2"] = "proString";
            properties["proper3"] = true;
            properties["proper4"] = DateTime.Now;
            DataEyeAnalyticsAPI.Track("TA_001", properties, DateTime.Now.AddHours(-1));
        }
        GUILayout.EndHorizontal();




        GUILayout.Space(20);
        GUILayout.Label("用户属性", GUI.skin.label);
        GUILayout.BeginHorizontal(GUI.skin.textArea, GUILayout.Height(Height));
        if (GUILayout.Button("UserSet", GUILayout.Height(Height)))
        {
            Dictionary<string, object> userProperties = new Dictionary<string, object>();
            userProperties["UserProperty1"] = 1;
            userProperties["UserProperty2"] = false;
            userProperties["UserProperty3"] = DateTime.Now;
            userProperties["UserProperty4"] = "UserStrProperty";
            DataEyeAnalyticsAPI.UserSet(userProperties,DateTime.Now.AddHours(-1));
        }

        GUILayout.Space(20);
        if (GUILayout.Button("UserSetOnce", GUILayout.Height(Height)))
        {
            Dictionary<string, object> userProperties = new Dictionary<string, object>();
            userProperties["UserProperty1"] = 1;
            userProperties["UserProperty2"] = false;
            userProperties["UserProperty3"] = DateTime.Now;
            userProperties["UserProperty4"] = "UserStrProperty";
            DataEyeAnalyticsAPI.UserSetOnce(userProperties);

        }
        GUILayout.Space(20);
        if (GUILayout.Button("UserAdd", GUILayout.Height(Height)))
        {
            DataEyeAnalyticsAPI.UserAdd("UserCoin", 1);
        }
        GUILayout.Space(20);
        if (GUILayout.Button("UserUnset", GUILayout.Height(Height)))
        {
            DataEyeAnalyticsAPI.UserUnset("UserProperty1");
        }
        GUILayout.Space(20);
        if (GUILayout.Button("UserDelete", GUILayout.Height(Height)))
        {
            DataEyeAnalyticsAPI.UserDelete();
        }
        GUILayout.Space(20);
        if (GUILayout.Button("UserAppend", GUILayout.Height(Height)))
        {
            List<string> stringList = new List<string>();
            stringList.Add("apple");
            stringList.Add("ball");
            stringList.Add("cat");
            DataEyeAnalyticsAPI.UserAppend(
                new Dictionary<string, object>
                {
                    {"USER_LIST", stringList }
                }
            );
        }
        GUILayout.EndHorizontal();

   

        GUILayout.Space(20);
        GUILayout.Label("其他配置选项", GUI.skin.label);
        GUILayout.BeginHorizontal(GUI.skin.textArea, GUILayout.Height(Height));
        if (GUILayout.Button("获取设备ID", GUILayout.Height(Height)))
        {
            Debug.Log("设备ID为:" + DataEyeAnalyticsAPI.GetDeviceId());
        }
        GUILayout.Space(20);
        if (GUILayout.Button("暂停数据上报", GUILayout.Height(Height)))
        {
            DataEyeAnalyticsAPI.EnableTracking(false);
        }

        GUILayout.Space(20);
        if (GUILayout.Button("继续数据上报", GUILayout.Height(Height)))
        {
            DataEyeAnalyticsAPI.EnableTracking(true);
        }
        GUILayout.Space(20);
        if (GUILayout.Button("停止数据上报", GUILayout.Height(Height)))
        {
            DataEyeAnalyticsAPI.OptOutTracking();
        }
        GUILayout.Space(20);
        if (GUILayout.Button("开始数据上报", GUILayout.Height(Height)))
        {
            DataEyeAnalyticsAPI.OptInTracking();
        }
       
        GUILayout.Space(20);
        if (GUILayout.Button("校准时间", GUILayout.Height(Height)))
        {
            //时间戳,单位毫秒 对应时间为1608782412000 2020-12-24 12:00:12
            DataEyeAnalyticsAPI.CalibrateTime(1608782412000);
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(20);
        GUILayout.Label("设置公共属性", GUI.skin.label);
        GUILayout.BeginHorizontal(GUI.skin.textArea, GUILayout.Height(Height));
        if (GUILayout.Button("设置静态公共属性", GUILayout.Height(Height)))
        {
            Dictionary<string, object> superProperties = new Dictionary<string, object>();
            List<object> listProperties = new List<object>();
            superProperties["super1"] = 1;
            superProperties["super2"] = "superstring";
            superProperties["super3"] = false;
            superProperties["super4"] = DateTime.Now;
            listProperties.Add(2);
            listProperties.Add("superStr");
            listProperties.Add(true);
            listProperties.Add(DateTime.Now);
            superProperties["super5"] = listProperties;
            DataEyeAnalyticsAPI.SetSuperProperties(superProperties);
        }
        GUILayout.Space(20);
        if (GUILayout.Button("更新静态公共属性", GUILayout.Height(Height)))
        {
            Dictionary<string, object> superProperties = new Dictionary<string, object>();
            superProperties["super1"] = 2;
            superProperties["super6"] = "super6";
            DataEyeAnalyticsAPI.SetSuperProperties(superProperties);
        }
       
        GUILayout.Space(20);
        if (GUILayout.Button("清空部分静态公共属性", GUILayout.Height(Height)))
        {
            DataEyeAnalyticsAPI.UnsetSuperProperty("super1");
            DataEyeAnalyticsAPI.UnsetSuperProperty("superX");
        }

        GUILayout.Space(20);
        if (GUILayout.Button("清空所有静态公共属性", GUILayout.Height(Height)))
        {
            DataEyeAnalyticsAPI.ClearSuperProperties();
        }

        GUILayout.Space(20);
        if (GUILayout.Button("设置动态公共属性", GUILayout.Height(Height)))
        {
            DataEyeAnalyticsAPI.SetDynamicSuperProperties(this);
        }
        GUILayout.EndHorizontal();
        GUILayout.EndScrollView();
        GUILayout.EndArea();
    }
    private void Start()
    {
        DataEyeAnalyticsAPI.CalibrateTimeWithNtp("time.windows.com");
        //设置channel，换买量渠道需要更新
        Dictionary<string, object> superProperties = new Dictionary<string, object>()
        {
            {"channel", "unity"} //admob fb unty applovin
        };
        DataEyeAnalyticsAPI.SetSuperProperties(superProperties);

        // 开启自动采集事件
        DataEyeAnalyticsAPI.EnableAutoTrack(AUTO_TRACK_EVENTS.ALL);

        //首次登陆
        Dictionary<string, object> properties = new Dictionary<string, object>(){};
        TDFirstEvent firstEvent = new TDFirstEvent("USER_FIRST", properties);
        // 将AndroidID设置为首次事件的FIRST_CHECK_ID
        DataEyeAnalyticsAPI.Track(firstEvent);       
        DataEyeAnalyticsAPI.Flush();

        //库存
        Dictionary<string, object> properties1 = new Dictionary<string, object>();
        properties1["ad_type"] = "Rewareded Video";  //Native，RewardedVideo，Banner，Interstitial，Splash
        DataEyeAnalyticsAPI.Track("ad_inventory", properties1);
        DataEyeAnalyticsAPI.Flush();

        //展示
        Dictionary<string, object> properties2 = new Dictionary<string, object>();
        properties2["ad_type"] = "RewardedVideo";  //Native，RewardedVideo，Banner，Interstitial，Splash
        DataEyeAnalyticsAPI.Track("ad_impression", properties2);
        DataEyeAnalyticsAPI.Flush();

        //点击
        Dictionary<string, object> properties3 = new Dictionary<string, object>();
        properties3["ad_type"] = "Rewareded Video";  //Native，RewardedVideo，Banner，Interstitial，Splash
        DataEyeAnalyticsAPI.Track("ad_click", properties3);
        DataEyeAnalyticsAPI.Flush();

        //上报展示 测试代码
        Dictionary<string, object> properties4 = new Dictionary<string, object>();
        properties4["NetworkFirmId"] = "admob_test";
        properties4["NetworkPlacementId"] = "100111_test";
        properties4["Revenue"] = 0.8;
        properties4["TopOnPlacementId"] = "adUnitIdentifier_test";
        properties4["AdType"] = "Native";
        properties4["Currency"] = "USD";
        DataEyeAnalyticsAPI.Track("ad_imp", properties4);
        DataEyeAnalyticsAPI.Flush();

        //通关
        Dictionary<string, object> properties5 = new Dictionary<string, object>();
        properties5["pass"] = "1";  //Native，RewardedVideo，Banner，Interstitial，Splash
        DataEyeAnalyticsAPI.Track("pass_checkpoint", properties5);
    }
}
