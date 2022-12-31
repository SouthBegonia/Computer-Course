using System;
using System.Collections.Generic;

//中介者模式
namespace MediatorPattern
{
    /// <summary>
    /// 抽象中介者 - 聊天室
    /// </summary>
    public abstract class AbstractChatroom
    {
        public abstract bool register(Member member);
        public abstract bool sendText(String from, String to, String message);
        public abstract bool sendImage(String from, String to, String image);
    }

    /// <summary>
    /// 抽象组件 - 聊天成员
    /// </summary>
    public abstract class Member
    {
        protected AbstractChatroom chatroom;
        public String name { get; private set; }

        public Member(String name)
        {
            this.name = name;
        }

        public AbstractChatroom getChatroom()
        {
            return chatroom;
        }

        public void setChatroom(AbstractChatroom chatroom)
        {
            this.chatroom = chatroom;
        }

        public abstract bool sendText(String to, String message);
        public abstract bool sendImage(String to, String image);

        public void receiveText(String from, String message)
        {
            Console.WriteLine($"<{name}> 收到来自 <{from}> 的文本消息：\"{message}\"");
        }

        public void receiveImage(String from, String image)
        {
            Console.WriteLine($"<{name}> 收到来自 <{from}> 的图片消息：\"{image}\"");
        }
    }

    /// <summary>
    /// 具体中介者 - 聊天室
    /// </summary>
    public class ChatGroup : AbstractChatroom
    {
        private Dictionary<string, Member> allMembersDic = new Dictionary<string, Member>();

        public override bool register(Member member)
        {
            if (!allMembersDic.ContainsValue(member))
            {
                allMembersDic.Add(member.name, member);

                //建立成员与聊天室的关联
                member.setChatroom(this);
                Console.WriteLine($"用户 <{member.name}> 加入了聊天室. 会员等级为：{member.GetType()}");
                return true;
            }

            return false;
        }

        public override bool sendText(String from, String to, String message)
        {
            if (allMembersDic.TryGetValue(to, out Member receiveMember))
            {
                receiveMember.receiveText(from, message);
                return true;
            }

            return false;
        }

        public override bool sendImage(String from, String to, String image)
        {
            if (allMembersDic.TryGetValue(to, out Member receiveMember))
            {
                receiveMember.receiveImage(from, image);
                return true;
            }

            return false;
        }
    }

    #region 具体组件 - 聊天成员

    public class CommonMember : Member
    {
        public CommonMember(String name) : base(name)
        {
        }

        public override bool sendText(String to, String message)
        {
            chatroom.sendText(name, to, message);
            return true;
        }

        public override bool sendImage(String to, String image)
        {
            Console.WriteLine($"Failed to sendImage >>>>> 普通成员 <{name}> 不能发送图片");
            return false;
        }
    }

    public class VIPMember : Member
    {
        public VIPMember(String name) : base(name)
        {
        }

        public override bool sendText(String to, String message)
        {
            chatroom.sendText(name, to, message);
            return true;
        }

        public override bool sendImage(String to, String image)
        {
            chatroom.sendText(name, to, image);
            return true;
        }
    }

    #endregion


    class Client
    {
        static void Main()
        {
            //创建 具体组件 - 聊天成员
            string memberAName = "路人A";
            string memberBName = "会员B";
            Member memberA = new CommonMember(memberAName);
            Member memberB = new VIPMember(memberBName);

            //创建 具体中介者 - 聊天室
            AbstractChatroom chatroom = new ChatGroup();

            //建立 组件与中介者的联系 - 聊天成员注册到聊天室
            chatroom.register(memberA);
            chatroom.register(memberB);

            Console.WriteLine();

            //组件通过中介者进行交互
            memberA.sendText(memberBName, "Hello");
            memberA.sendImage(memberBName, "A.jpg");
            memberB.sendText(memberAName, "Hi");
            memberB.sendImage(memberAName, "B.jpg");
        }
    }
}