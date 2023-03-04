export enum GenderEnum {
    Male = 'Male',
    Female = 'Female',
    Other = "Other"
  }

  const gender: GenderEnum = GenderEnum.Male;
const genderString: string = GenderEnum[gender];
console.log(genderString); // Output: 'Male'