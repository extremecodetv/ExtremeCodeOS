open System
open System.Management
open System.Diagnostics
open System.IO

let getSysData () =
    let wql = ObjectQuery("SELECT * FROM Win32_OperatingSystem");
    let searcher = new ManagementObjectSearcher(wql);
    let results = searcher.Get();
    let arrResults = Array.create 1 null
    results.CopyTo(arrResults, 0)
    arrResults

let limpopoPath = @$"{Environment.CurrentDirectory}\..\..\..\..\..\Games\Limpopo\limpopo.exe"

[<EntryPoint>]
let main _ =
    let loop = async {
        while true do
            let! sleep = Async.Sleep(3000);

            let data = getSysData()
            data 
            |> Array.iter(fun d -> 
                if d <> null
                then 
                    let total = Convert.ToDouble(d.["TotalVisibleMemorySize"])
                    let free = Convert.ToDouble(d.["FreePhysicalMemory"])
                    if free / total < 0.5
                    then 

                        let info = ProcessStartInfo(limpopoPath, "\q"); 
                        info.CreateNoWindow <- false;
                        info.UseShellExecute <- true;
                        let proc = Process.Start info
                        ()
                    )
            ()
    }
    
    loop |> Async.RunSynchronously

    0 