let passcode = "secret passcode";

class Hacker {
    private _hackerName: string;

    get hackerName(): string {
        return this._hackerName;
    }

    set hackerName(newName: string) {
        if (passcode && passcode == "secret passcode") {
            this._hackerName= newName;
        }
        else {
            console.log("Error: Unauthorized update of data!");
        }
    }
}
let hacker:Hacker = new Hacker();
hacker.hackerName = "Edward Snowden";
if (hacker.hackerName) {
    console.log(hacker.hackerName);
}
