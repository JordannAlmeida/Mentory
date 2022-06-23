class Penguim extends Bird {

    override peck(): void {
        //I can do this my way
    }

    override fly(): void {
        //O.o I can't do this
        throw Error;
    }
}