using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Primitives;

namespace SignalrBase.Hubs
{
    public class ChatHub : Hub
    {
        // public static Dictionary<int, string> ConnectedUsers = new Dictionary<int, string>();
        
        //DEPENDENCY INJECTION FOR DATABASE CONTEXT
        // private DatabaseContext _dbContext;
        // public ChatHub(DatabaseContext dbContext)
        // {
        //     _dbContext = dbContext;
        // }

        public override Task OnConnectedAsync()
        {
            // //JWT Token or some token for user identity
            // var token = Context.GetHttpContext().Request.Headers["Authorization"];
            // //userıD is not neccesary. just we need to uniq data for each user.
            // //because we want to find user connectionId later
            // var userId = TokenParse(token);
            // if (ConnectedUsers.Keys.Any(e => e == userId))
            // {
            //     ConnectedUsers[userId] = Context.ConnectionId;
            // }
            // else
            // {
            //     ConnectedUsers.Add(userId, Context.ConnectionId);
            // }
            Console.WriteLine(Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            // var token = Context.GetHttpContext().Request.Headers["Authorization"];
            // var userId = TokenParse(token);
            // ConnectedUsers.Remove(userId);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string message)
        {
            await Clients.All.SendCoreAsync("ReceiveMessage", new object?[] {new {message=message}});
            // var token = Context.GetHttpContext().Request.Headers["Authorization"];
            // var userId = TokenParse(token);
            // var messageModel = new
            // {
            //     from = userId,
            //     to = to,
            //     message = message,
            //     createdAt = DateTime.Now
            // };
            // if (ConnectedUsers.Keys.Any(e => e == to))
            // {
            //     var connId = ConnectedUsers[to];
            //     await Clients.Client(connId).SendAsync("ReceiveMessage", messageModel);
            //     //you can save the message here
            //     // _dbContext.Messages.Add(message);
            //     // _dbContext.SaveChanges();
            // }
        }

        // private int TokenParse(StringValues token)
        // {
        //     //parse token and find userId
        //     return 10; //this must be uniq for each user
        // }
    }
}