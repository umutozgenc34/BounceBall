using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
using System;

public class AndroidExampleNotification : MonoBehaviour
{
    [SerializeField] private int notificationId;
    [SerializeField] private string channelIdExample;
    void Start()
    {
        //Debug.Log(DateTime.Now.ToString());
    }
#if UNITY_ANDROID

    public void NotificationExample(DateTime timeToFire)
    {
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel()
        {
            Id = channelIdExample,
            Name = "Example Name",
            Description = "This is just an example",
            Importance = Importance.Default
        };
        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

        AndroidNotification notification = new AndroidNotification()
        {
            Title = "Where Are You",
            Text = "Come back and play",
            SmallIcon = "default",
            LargeIcon = "default",
            FireTime = timeToFire

        };
        //AndroidNotificationCenter.SendNotification(notification, channelIdExample);
        AndroidNotificationCenter.SendNotificationWithExplicitID(notification, channelIdExample, notificationId);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus == false)
        {
            //DateTime whenToFire = DateTime.Now.AddDays(1);
            DateTime whenToFire = DateTime.Now.AddSeconds(10);
            NotificationExample(whenToFire);
        }
        else
        {
            //AndroidNotificationCenter.CancelAllScheduledNotifications();
            AndroidNotificationCenter.CancelScheduledNotification(notificationId);
        }
    }
#endif
}
