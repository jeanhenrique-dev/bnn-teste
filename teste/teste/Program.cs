using System.Diagnostics;
using JeanHenrique;

var network = new Network(8);

// valores informados no doc do teste
network.Connect(1, 2);
network.Connect(6, 2);
network.Connect(2, 4);
network.Connect(5, 8);

foreach (var kvp in network.Numbers)
{
    Console.WriteLine($"Key: {kvp.Key}, Values: [{string.Join(", ", kvp.Value)}]");
}

//status de finalização do processo
Console.WriteLine("Finished");


// testes
Debug.Assert(network.Query(1, 2));
Debug.Assert(network.Query(6, 2));
Debug.Assert(network.Query(2, 4));
Debug.Assert(network.Query(5, 8));

Debug.Assert(network.Query(1, 6));
Debug.Assert(network.Query(2, 6));
Debug.Assert(network.Query(6, 1));
Debug.Assert(network.Query(6, 2));

Debug.Assert(network.Query(4, 6));
Debug.Assert(network.Query(4, 1));
Debug.Assert(network.Query(4, 2));

Debug.Assert(network.Query(1, 4));

Debug.Assert(network.Query(8, 5));

Debug.Assert(!network.Query(7, 3));
Debug.Assert(!network.Query(8, 2));
Debug.Assert(!network.Query(1, 3));