﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Library
{
    public interface IRemoteEntity
    {
        void RegisterInitializationInfo(SysConfig sysConfig);
        void EstablishConnections();
        string GetEntityName();

        void Status();
        void Crash();
        void Freeze();
        void Unfreeze();
        void Disconnect();
    }

    public interface IRemoteBroker : IRemoteEntity
    {
        void DifundPublishEvent(Event e, string source, int seqNumber);
        void DifundSubscribeEvent(string topic, string source);
        void DifundUnSubscribeEvent(string topic, string source);
    }

    public interface IRemotePublisher : IRemoteEntity
    {
        void Publish(String topic, int nrEvents, int ms);

    }

    public interface IRemoteSubscriber : IRemoteEntity
    {
        void Subscribe(String topic);
        void Unsubscribe(String topic);
        void NotifyEvent(Event e);
    }

    public interface IRemotePuppetMaster
    {
        void RegisterSlave(String url);
        void RegisterBroker(String url, String name);
        void RegisterPublisher(String url, String name);
        void RegisterSubscriber(String url, String name);
        void Notify(String msg);
        void LogEventPublication(string publisher, string topicname, int eventNumber);
        void LogEventForwarding(string broker, string publisher, string topicname, int eventNumber);
        void LogEventDelivery(string subscriber, string publisher, string topicname, int eventNumber);
        void PostEntityProcessed();
    }

    public interface IRemotePuppetMasterSlave
    {
        void StartNewProcess(String objName, String objType, String objUrl);
    }
}