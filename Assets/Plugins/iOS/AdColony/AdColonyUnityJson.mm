#import "AdColonyUnityJson.h"
#import <Foundation/Foundation.h>
#import "AdColonyUnityConstants.h"


@implementation NSString (adcJsonParsing)

- (NSDictionary *)jsonStringToDictionary {
    NSData *data = [self dataUsingEncoding:NSUTF8StringEncoding];
    id json = [NSJSONSerialization JSONObjectWithData:data options:0 error:nil];
    return json;
}

@end


@implementation NSDictionary (adcJsonParsing)

- (NSString *)toJsonString {
    NSError *error;
    NSData *jsonData = [NSJSONSerialization dataWithJSONObject:self options:0 error:&error];
    if (jsonData) {
        return [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
    }
    return nil;
}

@end


@implementation NSArray (adcJsonParsing)

- (NSString *)toJsonString {
    NSError *error;
    NSData *jsonData = [NSJSONSerialization dataWithJSONObject:self options:0 error:&error];
    if (jsonData) {
        return [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
    }
    return nil;
}

@end


@implementation AdColonyAppOptions (adcJsonParsing)

- (void)setupWithJson:(NSString *)jsonString {
    if (jsonString == nil) {
        return;
    }
    
    NSDictionary *appOptionsDictionary = [jsonString jsonStringToDictionary];
    for (NSString *key in [appOptionsDictionary allKeys]) {
        id obj = appOptionsDictionary[key];
        if (obj) {
            if ([key containsString:ADC_CONSENT_STRING]) {
                NSString *string = (NSString *)obj;
                NSArray *arrayOfComponents = [key componentsSeparatedByString:ADC_CONSENT_STRING];               
                [self setPrivacyConsentString:string forType:arrayOfComponents[0]];
            } else if ([key containsString:ADC_CONSENT_REQUIRED]) {
                NSArray *arrayOfComponents = [key componentsSeparatedByString:ADC_CONSENT_REQUIRED];
                if([obj boolValue] == YES) {
                    [self setPrivacyFrameworkOfType:arrayOfComponents[0] isRequired:true];
                } else {
                    [self setPrivacyFrameworkOfType:arrayOfComponents[0] isRequired:false];
                }
            } else if ([obj isKindOfClass:[NSString class]]) {
                NSString *string = (NSString *)obj;
                if ([key isEqualToString:ADC_APPOPTIONS_USER_ID_KEY]) {
                    self.userID = string;
                } else if ([key isEqualToString:ADC_APPOPTIONS_GDPR_CONSENT_STRING]) {
                    self.gdprConsentString = string;
                } else {
                    [self setOption:key withStringValue:string];
                }
            } else if ([obj isKindOfClass:[NSNumber class]]) {
                NSNumber *number = (NSNumber *)obj;
                if ([key isEqualToString:ADC_APPOPTIONS_ORIENTATION]) {
                    self.adOrientation = (AdColonyOrientation)[number intValue];
                } else if (([key isEqualToString:ADC_APPOPTIONS_DISABLE_LOGGING_KEY])) {
                    self.disableLogging = [number boolValue];
                } else if (([key isEqualToString:ADC_APPOPTIONS_GDPR_REQUIRED])) {
                    self.gdprRequired = [number boolValue];
                } else {
                    [self setOption:key withNumericValue:number];
                }
            } else if ([obj isKindOfClass:[NSDictionary class]]) {
                if ([key isEqualToString:ADC_OPTIONS_METADATA_KEY]) {
                    self.userMetadata = [[AdColonyUserMetadata alloc] init];
                    [self.userMetadata setupWithDictionary:(NSDictionary *)obj];
                }
            }
        }
    }
}

- (NSString *)toJsonString {
    // TODO: implement if needed.
    return nil;
}

@end


@implementation AdColonyAdOptions (adcJsonParsing)

- (void)setupWithJson:(NSString *)jsonString {
    if (jsonString == nil) {
        return;
    }
    
    NSDictionary *appOptionsDictionary = [jsonString jsonStringToDictionary];
    for (NSString *key in [appOptionsDictionary allKeys]) {
        id obj = appOptionsDictionary[key];
        if (obj) {
            if ([obj isKindOfClass:[NSString class]]) {
                NSString *string = (NSString *)obj;
                [self setOption:key withStringValue:string];
            } else if ([obj isKindOfClass:[NSNumber class]]) {
                NSNumber *number = (NSNumber*)obj;
                if (([key isEqualToString:ADC_ADOPTIONS_PRE_POPUP_KEY])) {
                    self.showPrePopup = [number boolValue];
                } else if ([key isEqualToString:ADC_ADOPTIONS_POST_POPUP_KEY]) {
                    self.showPostPopup = [number boolValue];
                } else {
                    [self setOption:key withNumericValue:number];
                }
            } else if ([obj isKindOfClass:[NSDictionary class]]) {
                if ([key isEqualToString:ADC_OPTIONS_METADATA_KEY]) {
                    self.userMetadata = [[AdColonyUserMetadata alloc] init];
                    [self.userMetadata setupWithDictionary:(NSDictionary *)obj];
                }
            }
        }
    }
}

- (NSString *)toJsonString {
    // TODO: implement if needed.
    return nil;
}

@end


@implementation AdColonyZone (adcJsonParsing)

- (void)setupWithJson:(NSString *)jsonString {
    // TODO: implement if needed.
}

- (NSString *)toJsonString {
    NSDictionary *zoneData = @{
        ADC_ZONE_IDENTIFIER_KEY         : self.identifier,
        ADC_ZONE_TYPE_KEY               : [NSString stringWithFormat:@"%lu", (unsigned long)self.type],
        ADC_ZONE_ENABLED_KEY            : [NSNumber numberWithBool:self.enabled],
        ADC_ZONE_REWARDED_KEY           : [NSNumber numberWithBool:self.rewarded],
        ADC_ZONE_VIEWS_PER_REWARD_KEY   : [NSString stringWithFormat:@"%lu", (unsigned long)self.viewsPerReward],
        ADC_ZONE_VIEWS_UNTIL_REWARD_KEY : [NSString stringWithFormat:@"%lu", (unsigned long)self.viewsUntilReward],
        ADC_ZONE_REWARD_AMOUNT_KEY      : [NSString stringWithFormat:@"%lu", (unsigned long)self.rewardAmount],
        ADC_ZONE_REWARD_NAME_KEY        : self.rewardName};
    return [zoneData toJsonString];
}

@end


@implementation AdColonyUserMetadata (adcJsonParsing)

- (void)setupWithDictionary:(NSDictionary *)dictionary {
    if (dictionary == nil) {
        return;
    }
    
    for (NSString *key in [dictionary allKeys]) {
        id obj = dictionary[key];
        if (obj) {
            if ([obj isKindOfClass:[NSString class]]) {
                NSString *string = (NSString *)obj;
                if ([key isEqualToString:ADC_USER_METADATA_GENDER_KEY]) {
                    self.userGender = string;
                } else if ([key isEqualToString:ADC_USER_METADATA_ZIPCODE_KEY]) {
                    self.userZipCode = string;
                } else if ([key isEqualToString:ADC_USER_METADATA_MARITAL_STATUS_KEY]) {
                    self.userMaritalStatus = string;
                } else if ([key isEqualToString:ADC_USER_METADATA_EDUCATION_LEVEL_KEY]) {
                    self.userEducationLevel = string;
                } else {
                    [self setMetadataWithKey:key andStringValue:string];
                }
            } else if ([obj isKindOfClass:[NSNumber class]]) {
                NSNumber *number = (NSNumber*)obj;
                if (([key isEqualToString:ADC_USER_METADATA_AGE_KEY])) {
                    self.userAge = [number intValue];
                } else if ([key isEqualToString:ADC_USER_METADATA_LATITUDE_KEY]) {
                    self.userLatitude = number;
                } else if ([key isEqualToString:ADC_USER_METADATA_LONGITUDE_KEY]) {
                    self.userLongitude = number;
                } else if ([key isEqualToString:ADC_USER_METADATA_HOUSEHOLD_INCOME_KEY]) {
                    self.userHouseholdIncome = number;
                } else {
                    [self setMetadataWithKey:key andNumericValue:number];
                }
            } else if ([obj isKindOfClass:[NSArray class]]) {
                NSArray* array = [(NSArray*)obj copy];
                if ([key isEqualToString:ADC_USER_METADATA_INTERESTS_KEY]) {
                    self.userInterests = array;
                } else {
                    [self setMetadataWithKey:key andArrayValue:array];
                }
            }
        }
    }
}

- (void)setupWithJson:(NSString *)jsonString {
    if (jsonString == nil) {
        return;
    }
    
    [self setupWithDictionary:[jsonString jsonStringToDictionary]];
}

- (NSString *)toJsonString {
    NSDictionary *userMetadataData = @{
        ADC_USER_METADATA_AGE_KEY : @(self.userAge),
        ADC_USER_METADATA_INTERESTS_KEY : self.userInterests,
        ADC_USER_METADATA_GENDER_KEY : [NSString stringWithFormat:@"%@", self.userGender],
        ADC_USER_METADATA_LATITUDE_KEY : [NSString stringWithFormat:@"%@", self.userLatitude],
        ADC_USER_METADATA_LONGITUDE_KEY : [NSString stringWithFormat:@"%@", self.userLongitude],
        ADC_USER_METADATA_ZIPCODE_KEY : self.userZipCode,
        ADC_USER_METADATA_HOUSEHOLD_INCOME_KEY : [NSString stringWithFormat:@"%@", self.userHouseholdIncome],
        ADC_USER_METADATA_MARITAL_STATUS_KEY : self.userMaritalStatus,
        ADC_USER_METADATA_EDUCATION_LEVEL_KEY : self.userEducationLevel};
    return [userMetadataData toJsonString];
}

@end
