using System;
using System.Collections.Generic;
using System.Text;
using AccCoreLib;

namespace Logic
{
    public static class EventHandler
    {

        //MIME type for IM retrival
        internal const String MIME_TYPE = @"application/xhtml+xml";

        //enum for local user states
        private enum InternalUserStateFlags
        {
            SignedOnline = 0,
            SignedOffline = 1,
            WentAway = 2,
            WentIdle = 3
        }

        //the return text for the request propeties
        private static String strReturnRequest = "";

        #region Events

        //delegates and events
        public delegate void delSuccessfulLogin();
        public static event delSuccessfulLogin SuccessfulLogin;
        public delegate void delUnknownSignonError();
        public static event delUnknownSignonError UnknownSignonError;
        public delegate void delInvalidScreenName();
        public static event delInvalidScreenName InvalidScreenName;
        public delegate void delInvalidPassword();
        public static event delInvalidPassword InvalidPassword;
        public delegate void delGroupsLoaded(List<KeyValuePair<int, String>> Groups);
        public static event delGroupsLoaded GroupsLoaded;
        public delegate void delNamesLoaded(List<String> Names);
        public static event delNamesLoaded NamesLoaded;
        public delegate void delBuddySignedOnline(String Name, String[] Groups);
        public static event delBuddySignedOnline BuddySignedOnline;
        public delegate void delBuddySignedOffline(String Name, String[] Groups);
        public static event delBuddySignedOffline BuddySignedOffline;
        public delegate void delBuddyWentAway(String Name, String[] Groups);
        public static event delBuddyWentAway BuddyWentAway;
        public delegate void delBuddyWentIdle(String Name, String[] Groups);
        public static event delBuddyWentIdle BuddyWentIdle;
        public delegate void delInstantMessageReceived(String user, String text, IAccImSession imSess);
        public static event delInstantMessageReceived InstantMessageReceived;
        public delegate void delInfoReceived(String user, String text);
        public static event delInfoReceived InfoReceived;
        public delegate void delAwayMessageReveived(String user, String text);
        public static event delAwayMessageReveived AwayMessageReceived;
        public delegate void delRateStateChanged(IAccImSession imSess, AccRateState NewState);
        public static event delRateStateChanged RateStateChanged;

        #endregion

        //session var
        internal static AccSession accSess = null;

        /// <summary>
        /// Gets or Sets the AccSession object to be used for event handling.
        /// </summary>
        public static AccSession Session
        {
            get { return accSess; }
            set { accSess = value; }
        }


        /// <summary>
        /// Void to subscribe to events. NOTE: this cannot be done via the static constructor because the AccSession object wont be set by then.
        /// </summary>
        [System.Diagnostics.DebuggerStepThrough]
        public static void Subscribe()
        {

            //subscribe to events
            accSess.BeforeImReceived += new DAccEvents_BeforeImReceivedEventHandler(session_BeforeImReceived);
            accSess.BeforeImSend += new DAccEvents_BeforeImSendEventHandler(session_BeforeImSend);
            accSess.OnAlertReceived += new DAccEvents_OnAlertReceivedEventHandler(session_OnAlertReceived);
            accSess.OnBuddyAdded += new DAccEvents_OnBuddyAddedEventHandler(session_OnBuddyAdded);
            accSess.OnBuddyMoved += new DAccEvents_OnBuddyMovedEventHandler(session_OnBuddyMoved);
            accSess.OnBuddyRemoved += new DAccEvents_OnBuddyRemovedEventHandler(session_OnBuddyRemoved);
            accSess.OnChangesBegin += new DAccEvents_OnChangesBeginEventHandler(session_OnChangesBegin);
            accSess.OnChangesEnd += new DAccEvents_OnChangesEndEventHandler(session_OnChangesEnd);
            accSess.OnDeliverStoredImsResult += new DAccEvents_OnDeliverStoredImsResultEventHandler(session_OnDeliverStoredImsResult);
            accSess.OnGroupAdded += new DAccEvents_OnGroupAddedEventHandler(session_OnGroupAdded);
            accSess.OnGroupChange += new DAccEvents_OnGroupChangeEventHandler(session_OnGroupChange);
            accSess.OnGroupMoved += new DAccEvents_OnGroupMovedEventHandler(session_OnGroupMoved);
            accSess.OnGroupRemoved += new DAccEvents_OnGroupRemovedEventHandler(session_OnGroupRemoved);
            accSess.OnIdleStateChange += new DAccEvents_OnIdleStateChangeEventHandler(session_OnIdleStateChange);
            accSess.OnImReceived += new DAccEvents_OnImReceivedEventHandler(session_OnImReceived);
            accSess.OnImSendResult += new DAccEvents_OnImSendResultEventHandler(session_OnImSendResult);
            accSess.OnImSent += new DAccEvents_OnImSentEventHandler(session_OnImSent);
            accSess.OnInputStateChange += new DAccEvents_OnInputStateChangeEventHandler(session_OnInputStateChange);
            accSess.OnRateLimitStateChange += new DAccEvents_OnRateLimitStateChangeEventHandler(session_OnRateLimitStateChange);
            accSess.OnStateChange += new DAccEvents_OnStateChangeEventHandler(accSess_OnStateChange);
            accSess.OnUserChange += new DAccEvents_OnUserChangeEventHandler(accSess_OnUserChange);
            accSess.OnUserRequestPropertyResult += new DAccEvents_OnUserRequestPropertyResultEventHandler(accSess_OnUserRequestPropertyResult);

        }


        #region Buddy States

        private static void accSess_OnUserChange(AccSession session, IAccUser oldUser, IAccUser newUser, AccUserProp Property, AccResult hr)
        {
            
            //get states
            AccUserState oldState = (AccUserState)oldUser.get_Property(AccUserProp.AccUserProp_State);
            AccUserState newState = (AccUserState)newUser.get_Property(AccUserProp.AccUserProp_State);

            //compare old state to the new state to figure out what happened to the buddy
            switch (oldState)
            {

                case AccUserState.AccUserState_Away:
                    switch (newState)
                    {
                        case AccUserState.AccUserState_Idle:
                            //buddy went from just Away to Away and Idle
                            BuddyStateChanged(newUser, InternalUserStateFlags.WentIdle);
                            break;
                        case AccUserState.AccUserState_Offline:
                        case AccUserState.AccUserState_Unknown:
                            //buddy went from Away to Offline
                            BuddyStateChanged(newUser, InternalUserStateFlags.SignedOffline);
                            break;
                        case AccUserState.AccUserState_Online:
                            //buddy went from Away to just Online (aka took away down)
                            BuddyStateChanged(newUser, InternalUserStateFlags.SignedOnline);
                            break;
                    }
                    break;
                case AccUserState.AccUserState_Idle:
                    switch (newState)
                    {
                        case AccUserState.AccUserState_Away:
                            //buddy went from just Idle to Away and Idle
                            BuddyStateChanged(newUser, InternalUserStateFlags.WentAway);
                            break;
                        case AccUserState.AccUserState_Offline:
                        case AccUserState.AccUserState_Unknown:
                            //buddy went from Idle to Offline
                            BuddyStateChanged(newUser, InternalUserStateFlags.SignedOffline);
                            break;
                        case AccUserState.AccUserState_Online:
                            //buddy went from Idle to Online (aka no longer Idle)
                            BuddyStateChanged(newUser, InternalUserStateFlags.SignedOnline);
                            break;
                    }
                    break;
                case AccUserState.AccUserState_Offline:
                case AccUserState.AccUserState_Unknown:
                    switch (newState)
                    {
                        case AccUserState.AccUserState_Away:
                            //buddy went from Offline to Away (aka Signed On then Went Away)
                            BuddyStateChanged(newUser, InternalUserStateFlags.SignedOnline);
                            BuddyStateChanged(newUser, InternalUserStateFlags.WentAway);
                            break;
                        case AccUserState.AccUserState_Idle:
                            //buddy went from Offline to Idle (aka Signed On then Went Idle)
                            BuddyStateChanged(newUser, InternalUserStateFlags.SignedOnline);
                            BuddyStateChanged(newUser, InternalUserStateFlags.WentIdle);
                            break;
                        case AccUserState.AccUserState_Offline:
                        case AccUserState.AccUserState_Unknown:
                            //buddy went from Offline/Unknown to Offline/Unknown
                            BuddyStateChanged(newUser, InternalUserStateFlags.SignedOffline);
                            break;
                        case AccUserState.AccUserState_Online:
                            //buddy went from Offline to Online
                            BuddyStateChanged(newUser, InternalUserStateFlags.SignedOnline);
                            break;
                    }
                    break;
                case AccUserState.AccUserState_Online:
                    switch (newState)
                    {
                        case AccUserState.AccUserState_Away:
                            //buddy went from Online to Away
                            BuddyStateChanged(newUser, InternalUserStateFlags.WentAway);
                            break;
                        case AccUserState.AccUserState_Idle:
                            //buddy went from Online to Idle
                            BuddyStateChanged(newUser, InternalUserStateFlags.WentIdle);
                            break;
                        case AccUserState.AccUserState_Offline:
                        case AccUserState.AccUserState_Unknown:
                            //buddy went from Online to Offline/Unknown
                            BuddyStateChanged(newUser, InternalUserStateFlags.SignedOffline);
                            break;
                    }
                    break;
            }

        }

        public static String[] GetUsersGroupsNames(IAccUser user)
        {

            //get the groups as an object
            object[] groups = (object[])user.Groups;

            //array of names
            String[] names = new String[groups.Length];

            //set the name
            for (int i = 0; i < groups.Length; i++)
            {
                IAccGroup g = (IAccGroup)groups[i];
                names[i] = g.Name;
            }

            //return array
            return names;

        }

        private static void BuddyStateChanged(IAccUser user, InternalUserStateFlags state)
        {

            //temp buddy list var
            IAccBuddyList bl = accSess.BuddyList;

            //name of user/groups
            String strName = user.Name;
            String[] arrGroups = GetUsersGroupsNames(user);

            switch (state)
            {

                case InternalUserStateFlags.SignedOffline:
                    //raise offline event
                    if (BuddySignedOffline != null)
                        BuddySignedOffline.Invoke(strName, arrGroups);
                    break;
                case InternalUserStateFlags.SignedOnline:
                    //raise online event
                    if (BuddySignedOnline != null)
                        BuddySignedOnline.Invoke(strName, arrGroups);
                    break;
                case InternalUserStateFlags.WentAway:
                    //raise away event
                    if (BuddyWentAway != null)
                        BuddyWentAway.Invoke(strName, arrGroups);
                    break;
                case InternalUserStateFlags.WentIdle:
                    //raise idle event
                    if (BuddyWentIdle != null)
                        BuddyWentIdle.Invoke(strName, arrGroups);
                    break;

            }

        }

        #endregion

        private static void accSess_OnUserRequestPropertyResult(AccSession session, IAccUser user, AccUserProp Property, int transId, AccResult hr, object propertyValue)
        {

            //if its the idle time, raise the event if necessary
            if (Property == AccUserProp.AccUserProp_IdleTime)
            {

                //if the user's idle time is > 0 then raise idle event
                if ((int)propertyValue > 0)
                    BuddyWentIdle(user.Name, GetUsersGroupsNames(user));

            }
            else if (Property == AccUserProp.AccUserProp_Profile)
            {

                //profile is actually an IM object
                IAccIm im = (IAccIm)propertyValue;

                //dequeue the request
                Actions.QueueOfRequests.Dequeue();

                //check that this is the last queued request
                if (Actions.QueueOfRequests.Count < 1)
                {

                    //add the profile to the return var
                    strReturnRequest += im.GetConvertedText(MIME_TYPE);

                    //invoke info received event
                    if (InfoReceived != null)
                        InfoReceived.Invoke(user.Name, strReturnRequest);

                }
                else
                    //add the profile to the return
                    strReturnRequest = im.GetConvertedText(MIME_TYPE);

            }
            else if (Property == AccUserProp.AccUserProp_AwayMessage)
            {

                //away message is actually an IM object
                IAccIm im = (IAccIm)propertyValue;

                //dequeue the request
                Actions.QueueOfRequests.Dequeue();

                //check the request count
                if (Actions.QueueOfRequests.Count < 1)
                {

                    //put this text at the beginning of the request
                    strReturnRequest = im.GetConvertedText(MIME_TYPE) + strReturnRequest;

                    //invoke away message reveived event
                    if (AwayMessageReceived != null)
                        AwayMessageReceived.Invoke(user.Name, strReturnRequest);

                }
                else
                    //set the return request var as the decoded string
                    strReturnRequest = im.GetConvertedText(MIME_TYPE);

            }

        }

        #region Buddy List Loading

        private static void LoadBuddyListGroups()
        {

            //temp buddy list var
            AccCoreLib.IAccBuddyList bl = accSess.BuddyList;

            //list of KeyValue pairs
            List<KeyValuePair<int, String>> lst = new List<KeyValuePair<int, string>>();

            //iterate the groups
            for (int i = 0; i < bl.GroupCount; i++)
            {

                //get group name and position
                String strName = bl.GetGroupByIndex(i).Name;
                int intPosition = bl.GetGroupPosition(bl.GetGroupByIndex(i));

                //add to list
                lst.Add(new KeyValuePair<int, string>(intPosition, strName));

            }

            //add Offline group
            lst.Add(new KeyValuePair<int, string>(lst.Count, "Offline"));

            //raise event
            if (GroupsLoaded != null)
                GroupsLoaded.Invoke(lst);

        }

        private static void LoadBuddyListNames()
        {

            //get the buddy list from the session
            AccCoreLib.IAccBuddyList bl = accSess.BuddyList;

            //list of users
            List<String> lst = new List<string>();

            //iterate groups
            for (int i = 0; i < bl.GroupCount; i++)
                //iterate names in the group
                for (int j = 0; j < bl.GetGroupByIndex(i).BuddyCount; j++)
                {

                    //get user
                    IAccUser user = bl.GetGroupByIndex(i).GetBuddyByIndex(j);

                    //add user to dictionary
                    lst.Add(user.Name);

                }

            //raise the NamesLoaded event
            if (NamesLoaded != null)
                NamesLoaded.Invoke(lst);

        }

        [System.Diagnostics.DebuggerStepThrough()]
        public static Boolean IsGroupExpanded(String Group)
        {

            //get the group
            IAccGroup grp = accSess.BuddyList.GetGroupByName(Group);

            //get the collapsed property
            Boolean b = (Boolean)grp.get_Property(AccGroupProp.AccGroupProp_Collapsed);

            //return the opposite of the property since this asks if its collapsed
            return !b;
        }

        #endregion

        #region Sign On State

        private static void accSess_OnStateChange(AccSession session, AccSessionState State, AccResult hr)
        {

            #region State

            switch (State)
            {
                case AccSessionState.AccSessionState_Offline:
                    break;
                case AccSessionState.AccSessionState_Online:
                    if (SuccessfulLogin != null)
                    {
                        SuccessfulLogin.Invoke();
                        LoadBuddyListGroups();
                        LoadBuddyListNames();
                    }
                    break;
                default:
                    break;
            }

            #endregion

            #region Errors

            switch (hr)
            {
                case AccResult.ACC_E_CONNECT_ERROR:
                case AccResult.ACC_E_INVALID_CLIENT_INFO:
                    break;
                case AccResult.ACC_E_EXPIRED_KEY:
                case AccResult.ACC_E_RATE_LIMITED_KEY:
                case AccResult.ACC_E_SUSPENDED_KEY:
                case AccResult.ACC_E_INVALID_DATA:
                case AccResult.ACC_E_INVALID_KEY:
                case AccResult.ACC_E_INVALID_FINGERPRINT:
                    if (UnknownSignonError != null)
                        UnknownSignonError.Invoke();
                    break;
                //invalid SN or suspended SN
                case AccResult.ACC_E_SUSPENDED_IDENTITY:
                case AccResult.ACC_E_INVALID_IDENTITY:
                    if (InvalidScreenName != null)
                        InvalidScreenName.Invoke();
                    break;
                //invalid Password
                case AccResult.ACC_E_INVALID_PASSWORD:
                    if (InvalidPassword != null)
                        InvalidPassword.Invoke();
                    break;
                case AccResult.ACC_S:
                case AccResult.ACC_E:
                case AccResult.ACC_S_NO_CHANGE:
                case 0:
                    break;
                default:
                    System.Windows.Forms.MessageBox.Show(hr.ToString());
                    break;
            }

            #endregion

        }

        #endregion


        static void session_OnDeliverStoredImsResult(AccSession session, int transId, AccResult hr)
        {
            throw new NotImplementedException();
        }

        static void session_OnChangesEnd(AccSession session)
        {
            throw new NotImplementedException();
        }

        static void session_OnChangesBegin(AccSession session)
        {
            throw new NotImplementedException();
        }

        static void session_OnRateLimitStateChange(AccSession session, IAccImSession imSession, AccRateState State)
        {
            RateStateChanged.Invoke(imSession, State);
        }

        static void session_OnInputStateChange(AccSession session, IAccImSession imSession, string userName, AccImInputState State)
        {
            throw new NotImplementedException();
        }

        static void session_OnImSent(AccSession session, IAccImSession imSession, IAccParticipant recipient, IAccIm im)
        {
            throw new NotImplementedException();
        }

        static void session_OnImSendResult(AccSession session, IAccImSession imSession, IAccParticipant recipient, IAccIm im, AccResult hr)
        {
            throw new NotImplementedException();
        }

        static void session_OnImReceived(AccSession session, IAccImSession imSession, IAccParticipant sender, IAccIm im)
        {

            //convert IM to a String
            String strReceive = im.GetConvertedText(MIME_TYPE);

            //get timestamp
            String time = im.get_Property(AccImProp.AccImProp_Timestamp).ToString();
            time = time.Substring(time.IndexOf(":") - 2).Trim();

            //get if this is an auto-response
            if (Enum.GetName(typeof(AccImFlags), im.get_Property((AccImProp)AccImFlags.AccImFlags_AutoResponse)) == AccImFlags.AccImFlags_AutoResponse.ToString())
            {

                //add users sn and auto-response to the front of the text
                strReceive = "<font color=\"red\">AUTO RESPONSE FROM " + sender.Name + " (" + time + ")</font>: " + strReceive;

            }
            else
            {

                //add the users sn to the front of the text
                strReceive = "<font color=\"red\">" + sender.Name + " (" + time + ")</font>: " + strReceive;

            }

            //raise the event
            if (InstantMessageReceived != null)
                InstantMessageReceived.Invoke(sender.Name, strReceive, imSession);
   
        }

        static void session_OnIdleStateChange(AccSession session, int secondsSinceActivity)
        {
            throw new NotImplementedException();
        }

        static void session_OnGroupRemoved(AccSession session, IAccGroup group, AccResult hr)
        {
            throw new NotImplementedException();
        }

        static void session_OnGroupMoved(AccSession session, IAccGroup group, int fromPosition, int toPosition, AccResult hr)
        {
            throw new NotImplementedException();
        }

        static void session_OnGroupChange(AccSession session, IAccGroup group, AccGroupProp Property)
        {
            throw new NotImplementedException();
        }

        static void session_OnGroupAdded(AccSession session, IAccGroup group, int position, AccResult hr)
        {
            throw new NotImplementedException();
        }

        static void session_OnBuddyRemoved(AccSession session, IAccGroup group, IAccUser user, AccResult hr)
        {
            throw new NotImplementedException();
        }

        static void session_OnBuddyMoved(AccSession session, IAccUser user, IAccGroup fromGroup, int fromPosition, IAccGroup toGroup, int toPosition, AccResult hr)
        {
            throw new NotImplementedException();
        }

        static void session_OnBuddyAdded(AccSession session, IAccGroup group, IAccUser user, int position, AccResult hr)
        {
            throw new NotImplementedException();
        }

        static void session_OnAlertReceived(AccSession session, IAccAlert alert)
        {
            throw new NotImplementedException();
        }

        static void session_BeforeImSend(AccSession session, IAccImSession imSession, IAccParticipant recipient, IAccIm im)
        {
            throw new NotImplementedException();
        }

        static void session_BeforeImReceived(AccSession session, IAccImSession imSession, IAccParticipant sender, IAccIm im)
        {
            throw new NotImplementedException();
        }


    }
}
