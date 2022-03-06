module Client.Tests

#if FABLE_COMPILER
open Fable.Mocha
#else
open Expecto
#endif

open Index
open Shared

let client = testList "Client" [
    testCase "Added todo" <| fun _ ->
        //let newTodo = { ServerResponse = None; ValidationError = None; Text = "WC1 2PF"; ServerState = ServerState.Idle }
        let model, _ = init ()

        let model, _ = update (TextChanged (0, "1011")) model

        Expect.equal 1 model.Destinations.Length "There should be 1 todo"
        Expect.equal "1011" model.Destinations.[0].Text "text should be correct"

    testCase "adjective" <| fun _ ->
        [(1, "First"); (2, "2nd"); (3, "3rd"); (4, "4th"); (5, "5th"); (6, "6th"); (7, "7th"); (8, "8th"); (9, "9th"); (10, "10th")
         (11, "11th"); (12, "12th"); (13, "13th"); (14, "14th"); (15, "15th"); (16, "16th"); (17, "17th"); (18, "18th"); (19, "19th"); (20, "20th")
         (21, "21st"); (22, "22nd"); (23, "23rd"); (24, "24th"); (25, "25th"); (26, "26th"); (27, "27th"); (28, "28th"); (29, "29th"); (30, "30th")
         (100, "100th"); (101, "101st"); (102, "102nd"); (103, "103rd"); (104, "104th")
         (110, "110th"); (111, "111th"); (112, "112th"); (113, "113th"); (114, "114th")]
        |> List.iter (fun (n, res) -> Expect.equal (adjective (n-1)) res $"{n} should be {res}")
]

let all =
    testList "All"
        [
#if FABLE_COMPILER // This preprocessor directive makes editor happy
            Shared.Tests.shared
#endif
            client
        ]

[<EntryPoint>]
let main args =
#if FABLE_COMPILER
    Mocha.runTests all
#else
    runTestsWithArgs defaultConfig args all
#endif