using System.Linq;
using Ninject;
using Ninject.Parameters;
using Realm.Data.Definitions;
using Realm.Entity;
using Realm.Entity.Entities;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Network;

namespace Realm.Network.User
{
    /// <summary>
    ///
    /// </summary>
    public sealed class GameUser : Library.Common.Entity, IGameUser
    {
        ///  <summary>
        /// 
        ///  </summary>
        ///  <param name="ipAddress"></param>
        ///  <param name="tcpClient"></param>
        ///  <param name="tcpServer"></param>
        /// <param name="initAtom"></param>
        public GameUser(string ipAddress, ITcpUser tcpClient, DictionaryAtom initAtom)
            : base(0, "NewUser")
        {
            IKernel kernel = (IKernel)initAtom.GetObject("Ninject.Kernel");

            IpAddress = ipAddress;
            TcpClient = tcpClient;
            TcpServer = kernel.Get<ITcpServer>();
            MenuRepository = new MenuHandlerRepository();
            MenuRepository.Add("MainMenu",
                kernel.Get<IMenuHandler>("MainMenu", new Parameter("initAtom", initAtom, false)));

            TcpServer.OnNetworkMessageReceived += Server_OnNetworkMessageReceived;
        }

        private MenuHandlerRepository MenuRepository { get; set; }

        private ITcpServer TcpServer { get; set; }

        public new long ID { get; set; }

        public void SendText(string text)
        {
            throw new System.NotImplementedException();
        }

        public ICharacter CurrentCharacter
        {
            get { throw new System.NotImplementedException(); }
        }

        public string IpAddress { get; private set; }

        public string Username { get; private set; }

        public int PreHashID { get; private set; }

        public int PostHashID { get; private set; }

        public ITcpUser TcpClient { get; private set; }

        public void OnLoad(DictionaryAtom data)
        {
            Username = data.GetString("Username");
            ID = data.GetInt("UserID");
            PreHashID = data.GetInt("PreHashID");
            PostHashID = data.GetInt("PostHashID");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Server_OnNetworkMessageReceived(object sender, NetworkEventArgs e)
        {
            var commandHandled = MenuRepository.Values
                .Select(menu => menu.Execute(this, e.Message)).FirstOrDefault(handled => handled);

            if (!commandHandled)
            {
                // TODO: Throw an exception of some sort
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="menuName"></param>
        public void SendMenu(string menuName)
        {
            if (MenuRepository.Contains(menuName))
                MenuRepository.Get(menuName).SendMenu(this);
        }

        public void OnInit(DictionaryAtom initAtom)
        {
            throw new System.NotImplementedException();
        }

        public Definition Definition
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public string Description
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public string LongName
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public string PluralName
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public IGameEntity Location
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public IContext GetContext(string typeName)
        {
            throw new System.NotImplementedException();
        }
    }

    /*public class GameUser : Cell, IDisposable, IGameUser, IManagerReference, ILogging
    {
        private readonly Dictionary<string, IMenuHandler> MenuTable = new Dictionary<string, IMenuHandler>
                                                                 {
                                                                     { "main", new MainMenuHandler() },
                                                                     { "create", new CreateMenuHandler() },
                                                                     { "char", new CharMenuHandler() }
                                                                 };

        public GameUser(ITcpUser user)
        {
            TcpUser = user;
        }

        public void OnInit()
        {
            Properties = new PropertyContext(null);

            Characters = new CharacterHandler(this);
            Game.SetManagerReferences(Characters);

            NetworkManager.Server.OnNetworkMessageReceived += tcpServer_OnNetworkMessageReceived;

            UserState = Globals.Globals.UserStateTypes.MainMenu;
            SendMxpElements();
        }

        #region IDisposable

        private bool _disposed;
        public void Dispose()
        {
            Dispose(true);

            // Use SupressFinalize in case a subclass
            // of this type implements a finalizer.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // If you need thread safety, use a lock around these
            // operations, as well as in your methods that use the resource.
            if (!_disposed)
            {
                // Indicate that the instance has been disposed.
                _disposed = true;
            }
        }

        #endregion IDisposable

        public IEnumerable<CharacterData> UserCharacters { get { return Characters.Characters; } }
        public ITcpUser TcpUser { get; private set; }
        public Globals.Globals.UserStateTypes UserState { get; set; }
        public string Id { get { return TcpUser.Id; } }
        public int AccountId { get; set; }
        public IPropertyContext Properties { get; private set; }
        public ICharacterHandler Characters { get; private set; }

        void tcpServer_OnNetworkMessageReceived(object sender, NetworkEventArgs e)
        {
            if (!(sender is ITcpUser)) return;

            Game.Properties.SetProperty("current user", this);
            Properties.SetProperty("raw command", e.Message);
            Execute(e.Message);
        }

        private IMenuHandler GetMenu(string menu)
        {
            return MenuTable.ContainsKey(menu) ? MenuTable[menu] : null;
        }

        public void Execute(string str)
        {
            if (str.Length < 1) return;

            IMenuHandler menu;
            switch (UserState)
            {
                case Globals.Globals.UserStateTypes.None:
                    break;

                case Globals.Globals.UserStateTypes.Quitting:
                    Quit();
                    break;

                case Globals.Globals.UserStateTypes.LoggedIn:
                    CommandManager.Execute(this, str);
                    break;

                case Globals.Globals.UserStateTypes.MainMenu:
                    menu = GetMenu("main");
                    if (menu.IsNotNull())
                        menu.Execute();
                    break;

                case Globals.Globals.UserStateTypes.CharacterMenu:
                    menu = GetMenu("char");
                    if (menu.IsNotNull())
                        menu.Execute();
                    break;

                case Globals.Globals.UserStateTypes.CreateCharacter:
                    menu = GetMenu("create");
                    if (menu.IsNotNull())
                        menu.Execute();
                    break;

                case Globals.Globals.UserStateTypes.DeleteCharacter:
                    CommandManager.Execute(this, "playerdeletechar");
                    break;

                default:
                    Log.ErrorFormat("User[{0}] has an invalid UserState[{1}]", TcpUser.Id, UserState);
                    break;
            }
        }

        public void Load()
        {
            try
            {
                if (!LoadUserProperties())
                    return;

                UserState = Globals.Globals.UserStateTypes.CharacterMenu;
                if (!Characters.LoadCharacters())
                    return;

                if (!LuaManager.Execute("/events/OnPlayerLogin.lua", true))
                    return;

                Log.InfoFormat("User[{0}] loaded", ID);

                var thrownEvent = new OnUserLoaded
                    {
                        Sender = this,
                        Args = new RealmEventArgs(new EventTable { { "UserID", ID } })
                    };
                EventManager.ThrowEvent(this, thrownEvent);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                // TODO: User failed to load
            }
        }*/

    //private bool LoadUserProperties()
    // {
    //TODO: Fix this
    /*var propList = DatabaseManager.LiveContext.GetUserProperties((int)ID);
    foreach (var prop in propList)
    {
        Properties.SetProperty(
            prop["Name"].ToString(),
            prop["Value"],
            Convert.ToBoolean(prop["IsPersistable"]),
            Convert.ToBoolean(prop["IsVolatile"]),
            Convert.ToBoolean(prop["IsVisible"]));
        Log.InfoFormat("User[{0}, {1}] => SetProperty[{2}]", ID, Name, prop["Name"]);
    }*/
    //    return true;
    // }

    /*public void Quit(bool save = false)
    {
        if (save && Save())
        {
            Log.InfoFormat("User[{0}] saved.", TcpUser.Id);
            SendText(MessageResources.MSG_SAVE_SUCCESSFUL);
        }

        SendText(MessageResources.MSG_QUIT);
        TcpUser.Disconnect();
    }

    public bool Save()
    {
        // TODO: Save the character first?

        // TODO: GameUser:Save - Call sp_UpdateUserProperties
        return true;
    }

    public void SendText(string text)
    {
        //Properties.GetProperty<bool>("mxpEnabled")
        TcpUser.WriteToBuffer(text + Environment.NewLine);
    }

    private void SendMxpElements()
    {
        var sb = new StringBuilder();
        sb.Append(MxpExtensions.MxpTag("!-- Set up MXP elements --"));

        // Menu tags
        sb.Append(MxpExtensions.MxpTag("!ELEMENT GameTitle \"<FONT COLOR='#FF00FF' SIZE='5'><B>\""));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT MenuCmd1 \"<FONT COLOR=Cyan><B>\""));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT MenuCmd2 \"<FONT COLOR=Green><B>\""));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT MenuCmd3 \"<FONT COLOR=Red><B>\""));

        // Basic Tags
        sb.Append(MxpExtensions.MxpTag("!ELEMENT Id \"<FONT COLOR='#808000'><SMALL><I>\""));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT Item <FONT COLOR='#FF00FF'>"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT Mob <FONT COLOR='#00FF00'>"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT Effect <FONT COLOR='#FFFF00'>"));

        // Wizard Tags
        sb.Append(MxpExtensions.MxpTag("!ELEMENT WizEntity \"<send href='@examine &name;' hint='Examine &desc;'>\" ATT='name desc'"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT WizItem \"<send href='@examine &name;' hint='Examine &desc;'>\" ATT='name desc'"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT WizMob \"<send href='@examine &name;|@monitor &name;' hint='Examine &desc;|Toggle Monitor messaging on &desc;'>\" ATT='name desc'"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT WizPlayer <FONT COLOR='#00FFFF'>"));
        // WizSpace

        // Space tags
        sb.Append(MxpExtensions.MxpTag("!ELEMENT RName \"<FONT COLOR='#FF00FF' SIZE='5'><B>\" FLAG='SpaceName'"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT RDesc FLAG='SpaceDesc'"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT RExits \"<FONT COLOR='#FFA500' SIZE='3'>\" FLAG='SpaceExit'"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT Ex \"<send href='&name;|look &name;' hint='Look &desc;'>\" ATT='name desc'"));

        // item tag for things on the ground
        sb.Append(MxpExtensions.MxpTag("!ELEMENT GrndItem_DrinkCnt \"<send href='look &#39;&name;&#39;|get &#39;&name;&#39;|drink &#39;&name;&#39;' hint='Look &desc;|Pick Up &desc;|Drink from &desc;'>\" ATT='name desc'"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT GrndItem \"<send href='look &#39;&name;&#39;|get &#39;&name;&#39;' hint='Look &desc;|Pick Up &desc;'>\" ATT='name desc'"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT GrndItem_ResNode \"<send href='look &#39;&name;&#39;|gather &#39;&name;&#39;' hint='Look &desc;|Gather From &desc;'>\" ATT='name desc'"));

        // item tag for things in inventory
        sb.Append(MxpExtensions.MxpTag("!ELEMENT InvItem_Cnt \"<send href='look &#39;&name;&#39;|look in &#39;&name;&#39;|drop &#39;&name;&#39;|appraise &#39;&name;&#39;|sell &#39;&name;&#39;' hint='Look &desc;|Look inside &desc;|Drop &desc;|Appraise &desc;|Sell &desc;'>\" ATT='name desc'"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT InvItem_DrinkCnt \"<send href='look &#39;&name;&#39;|look in &#39;&name;&#39;|drop &#39;&name;&#39;|drink &#39;&name;&#39;|appraise &#39;&name;&#39;|sell &#39;&name;&#39;' hint='Look &desc;|Look inside &desc;|Drop &desc;|Drink &desc;|Appraise &desc;|Sell &desc;'>\" ATT='name desc'"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT InvItem_Food \"<send href='look &#39;&name;&#39;|drop &#39;&name;&#39;|eat &#39;&name;&#39;|appraise &#39;&name;&#39;|sell &#39;&name;&#39;' hint='Look &desc;|Drop &desc;|Eat &desc;|Appraise &desc;|Sell &desc;'"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT InvItem_Weapon \"<send href='look &#39;&name;&#39;|wield &#39;&name;&#39;|drop &#39;&name;&#39;|eat &#39;&name;&#39;|appraise &#39;&name;&#39;|sell &#39;&name;&#39;' hint='Look &desc;|Wield &desc;|Drop &desc;|Eat &desc;|Appraise &desc;|Sell &desc;'"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT InvItem_Recipe \"<send href='look &#39;&name;&#39;|create &#39;&prodName&#39;|drop &#39;&name;&#39;|appraise &#39;&name;&#39;|sell &#39;&name;&#39;' hint='Look &desc;|Create &prodDesc;|Drop &desc;|Appraise &desc;|Sell &desc;'>\" ATT='name desc prodName prodDesc'"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT InvItem \"<send href='look &#39;&name;&#39;|wear &#39;&name;&#39;|drop &#39;&name;&#39;|appraise &#39;&name;&#39;|sell &#39;&name;&#39;' hint='Look &desc;|Wear &desc;|Drop &desc;|Appraise &desc;|Sell &desc;'>\" ATT='name desc'"));

        // item tag for things that are worn
        sb.Append(MxpExtensions.MxpTag("!ELEMENT EqItem \"<send href='look &#39;&name;&#39;|remove &#39;&name;&#39;|appraise &#39;&name;&#39;' hint='Look &desc;|Remove &desc;|Appraise &desc;'>\" ATT='name desc'"));

        // buy items in shop
        sb.Append(MxpExtensions.MxpTag("!ELEMENT ShopItem \"<send href='look &#39;&shop;&#39; &#39;&name;&#39;|buy &#39;&name;&#39;' hint='Look &desc;|Buy &desc;'>\" ATT='shop name desc'"));

        // item tag for recipes that are memorized
        sb.Append(MxpExtensions.MxpTag("!ELEMENT Recipe \"<send href='look &#39;&name;&#39;|unlearn &#39;&name;&#39;' hint='Look &desc;|Unlearn &desc;'>\" ATT='name desc'"));

        // mobs
        sb.Append(MxpExtensions.MxpTag("!ELEMENT Shopkeep \"<send href='look &#39;&name;&#39;|greet &#39&name;&#39;|say &#39;&name;&#39; hello' hint='Look at &desc;|Greet &desc;|Say hello to &desc;'>\" ATT='name desc'"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT Guard \"<send href='look &#39;&name;&#39;|greet &#39&name;&#39;|say &#39;&name;&#39; hello' hint='Look at &desc;|Greet &desc;|Say hello to &desc;'>\" ATT='name desc'"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT Mob \"<send href='look &#39;&name;&#39;|con &#39;&name;&#39;|kill &#39;&name;&#39;|say &#39;&name;&#39; hello' hint='Look at &desc;|Consider &desc;|Kill &desc;|Say hello to &desc;'>\" ATT='name desc'"));

        // help
        sb.Append(MxpExtensions.MxpTag("!ELEMENT HelpEntry \"<send href='help &name;' hint='Help &desc;'>\" ATT='name desc'"));

        // Players
        //sb.Append(NetworkUtils.MxpTag("!ELEMENT User \"<send href='look &#39;&name;&#39;'>\" ATT='name'"));

        // Examine

        // channels
        sb.Append(MxpExtensions.MxpTag("!ELEMENT Error \"<FONT COLOR='#FFFF00'>\" OPEN"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT Debug \"<FONT COLOR='#FFFF00'><I>\" OPEN"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT Wizard \"<FONT COLOR='#FF0000'><I>\" OPEN"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT Builder \"<FONT COLOR='#FF8040'><I>\" OPEN"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT General \"<FONT COLOR='#808080'>\" OPEN"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT Marketplace \"<FONT COLOR='#FF0080'>\" OPEN"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT OOC \"<FONT COLOR='#00FFFF'>\" OPEN"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT Group \"<FONT COLOR='#0000FF'>\" OPEN"));
        sb.Append(MxpExtensions.MxpTag("!ELEMENT Tell \"<FONT COLOR='#FF00FF'>\" OPEN"));

        //sendText("<!-- the next elements deal with the MUD prompt -->"));
        //sendText("<!ELEMENT Prompt FLAG=\"Prompt\">"));
        //sendText("<!ELEMENT Hp FLAG=\"Set hp\">"));
        //sendText("<!ELEMENT MaxHp FLAG=\"Set maxhp\">"));
        //sendText("<!ELEMENT Mana FLAG=\"Set mana\">"));
        //sendText("<!ELEMENT MaxMana FLAG=\"Set maxmana\">"));

        /*sb.Append(NetworkUtils.MxpTag("STAT CurrentHealth MAX=MaximumHealth CAPTION=Health"));
        sb.Append(NetworkUtils.MxpTag("STAT CurrentMana MAX=MaximumMana CAPTION=Mana"));
        sb.Append(NetworkUtils.MxpTag("STAT CurrentStamina MAX=MaximumStamina CAPTION=Stamina"));

        sb.Append(NetworkUtils.MxpTag("!EN CurrentHealth PUBLISH"));
        sb.Append(NetworkUtils.MxpTag("!EN CurrentMana PUBLISH"));
        sb.Append(NetworkUtils.MxpTag("!EN CurrentStamina PUBLISH"));
        sb.Append(NetworkUtils.MxpTag("!EN MaximumHealth PUBLISH"));
        sb.Append(NetworkUtils.MxpTag("!EN MaximumMana PUBLISH"));
        sb.Append(NetworkUtils.MxpTag("!EN MaximumStamina PUBLISH"));*/

    //sb.Append(NetworkUtils.MxpTag("GAUGE CurrentHealth MAX=\"MaximumHealth\" CAPTION=\"Health\" COLOR=\"#FF0000\""));
    //sb.Append(NetworkUtils.MxpTag("GAUGE CurrentMana MAX=\"MaximumMana\" CAPTION=\"Mana\" COLOR=\"#0000FF\""));
    //sb.Append(NetworkUtils.MxpTag("GAUGE CurrentStamina MAX=\"MaximumStamina\" CAPTION=\"Stamina\" COLOR=\"#00FF00\""));
    /*
            TcpUser.WriteToBuffer(sb.ToString());
        }

        #region IManagerReference

        public IDataManager DataManager { get; set; }
        public IEntityManager EntityManager { get; set; }
        public ICommandManager CommandManager { get; set; }
        public IEventManager EventManager { get; set; }
        public ILuaManager LuaManager { get; set; }
        public IDatabaseManager DatabaseManager { get; set; }
        public ICombatManager CombatManager { get; set; }
        public IPathManager PathManager { get; set; }
        public IHelpManager HelpManager { get; set; }
        public ITimeManager TimeManager { get; set; }
        public INetworkManager NetworkManager { get; set; }
        public IChannelManager ChannelManager { get; set; }
        public IGame Game { get; set; }

        #endregion IManagerReference

        #region ILogging

        public LogWrapper Log { get; set; }

        #endregion ILogging
    }*/
}