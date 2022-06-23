class GameBirdsGood {
    _bird1: Bird
    _bird2: Bird

    initialize(): void {
        this._bird1 = new Parrot();
        this._bird2 = new Penguim();

        this._bird1.peck();
        this._bird1.fly();

        this._bird2.peck();
        this._bird2.fly(); //Oh nooooooooo
    }
}