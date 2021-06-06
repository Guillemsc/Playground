#pragma once

#import <AdColony/AdColony.h>


@interface NSString (adcJsonParsing)

- (NSDictionary *)jsonStringToDictionary;

@end


@interface NSDictionary (adcJsonParsing)

- (NSString *)toJsonString;

@end


@interface NSArray (adcJsonParsing)

- (NSString *)toJsonString;

@end


@interface AdColonyAppOptions (adcJsonParsing)

- (void) setupWithJson:(NSString *)jsonString;
- (NSString *)toJsonString;

@end


@interface AdColonyAdOptions (adcJsonParsing)

- (void) setupWithJson:(NSString *)jsonString;
- (NSString *)toJsonString;

@end


@interface AdColonyZone (adcJsonParsing)

- (void) setupWithJson:(NSString *)jsonString;
- (NSString *)toJsonString;

@end


@interface AdColonyUserMetadata (adcJsonParsing)

- (void)setupWithDictionary:(NSDictionary *)dictionary;
- (void) setupWithJson:(NSString *)jsonString;
- (NSString *)toJsonString;

@end
