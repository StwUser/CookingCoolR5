import { IGameModel } from "./Interfaces";

export interface IGameFullInfo {
  game: IGameModel | undefined,
  steamGame: ISteamGameModel | undefined
}

// Get Game by name
export interface IGetGameByName {
  gameName: string | null;
}

export interface ISteamGameModel {
  success: boolean | null,
  data: IData | null
}

export interface IData {
  type: string,
  name: string, 
  steamAppid: number | null,
  requiredAge: number | null,
  isFree: boolean | null,
  detailedDescription: string,
  aboutTheGame: string,
  shortDescription: string,
  fullGame: IFullGame,
  supportedLanguages: string,
  headerImage: string,
  capsuleImage: string,
  capsuleImagev5: string,
  website: string,
  pcRequirements: IPcRequirements[],
  macRequirements: IMacRequirements[],
  linuxRequirements: ILinuxRequirements[],
  legalNotice: string,
  developers: string[],
  publishers: string[],
  priceOverview: IPriceOverview,
  packages: number[]
  packageGroups: IPackageGroup[],
  platforms: IPlatforms
  categories: ICategory[]
  genres: IGenre[],
  screenshots: IScreenshot[],
  releaseDate: IReleaseDate,
  supportInfo: ISupportInfo,
  background: string,
  backgroundRaw: string,
  contentDescriptors: IContentDescriptors
}

export interface IFullGame {
  appid: string
  name: string
}

export interface IPcRequirements {
  minimum: string,
  recommended: string
}

export interface IMacRequirements {
  minimum: string,
  recommended: string  
}

export interface ILinuxRequirements {
  minimum: string,
  recommended: string
}

export interface IPriceOverview {
  currency: string,
  initial: number | null,
  final: number | null,
  discountPercent: number | null,
  initialFormatted: string,
  finalFormatted: string
}

export interface IPackageGroup {
  name: string,
  title: string,
  description: string,
  selectionText: string,
  saveText: string,
  displayType: number | null,
  isRecurringSubscription: string
  subs: ISub[]
}

export interface ISub {
  packageId: number | null,
  percentSavingsText: string,
  percentSavings: number | null,
  optionText: string,
  optionDescription: string
  canGetFreeLicense: string,
  isFreeLicense: boolean | null
  priceInCentsWithDiscount: number | null
}

export interface IPlatforms {
  windows: boolean | null,
  mac: boolean | null
  linux: boolean | null
}

export interface ICategory {
  id: number | null,
  description: string
}

export interface IGenre {
  id: number | null,
  description: string
}

export interface IScreenshot {
  id: number | null,
  pathThumbnail: string,
  pathFull: string  
}

export interface IReleaseDate {
  comingSoon: boolean | null,
  date: string
}

export interface ISupportInfo {
  url: string,
  email: string
}

export interface IContentDescriptors {
  ids: number[] | null
  notes: string
}