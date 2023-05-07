using System.Threading.Tasks;
using UnityEngine;

public class ServerManager : MonoBehaviour
{
    private Server server;
    private bool isRunning = false;

    private async void Start()
    {
        server = new Server(8888);
        isRunning = true;
        Debug.Log("Server started");
        await Task.Run(() => server.Start());
    }

    private void Update() {
        if (server.HasCommand())
        {
            string command = server.GetCommand();
            string[] str = command.Split(',');
            if(str[0]=="1")
            {
                Main.Instance.elevator1.move(int.Parse(str[1]),int.Parse(str[2]));
            }
            else if(str[0]=="2")
            {
                Main.Instance.elevator2.move(int.Parse(str[1]),int.Parse(str[2]));
            }
        }
    }

    private void OnApplicationQuit()
    {
        if (isRunning)
        {
            server.Stop();
        }
    }
}
