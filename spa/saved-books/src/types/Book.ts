import ILibrary from "./Library";

export default interface IBook {
    title: string,
    description: string,
    // usedId: string,
    id: string,
    library: ILibrary
    dateTimeToReturn: Date,
    dailyFee: number,
}
