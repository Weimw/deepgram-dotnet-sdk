﻿using AutoBogus;
using Deepgram.Models;
using Deepgram.Tests.Fakers;
using Deepgram.Utilities;
using Xunit;

namespace Deepgram.Tests.UtilitiesTests
{
    public class QueryParameterUtilTests
    {
        PrerecordedTranscriptionOptions prerecordedTranscriptionOptions;

        public QueryParameterUtilTests()
        {
            prerecordedTranscriptionOptions = new PrerecordedTranscriptionOptionsFaker().Generate();

        }

        [Fact]
        public void GetParameters_Should_Return_String_When_Passing_String_Parameter()
        {
            //Act
            var result = QueryParameterUtil.GetParameters(prerecordedTranscriptionOptions);

            //Assert
            Assert.NotNull(result);
            Assert.Contains($"{nameof(prerecordedTranscriptionOptions.Model).ToLower()}={prerecordedTranscriptionOptions.Model.ToLower()}", result);
        }
        [Fact]
        public void GetParameters_Should_Return_String_When_Passing_Int_Parameter()
        {
            //Arrange 
            var obj = new AutoFaker<ListAllRequestsOptions>().Generate();

            //Act
            var result = QueryParameterUtil.GetParameters(obj);

            //Assert
            Assert.NotNull(result);
            Assert.Contains($"{nameof(obj.Limit).ToLower()}={obj.Limit}", result);
        }

        [Fact]
        public void GetParameters_Should_Return_String_When_Passing_Array_Parameter()
        {
            //Act
            var result = QueryParameterUtil.GetParameters(prerecordedTranscriptionOptions);

            //Assert
            Assert.NotNull(result);
            Assert.Contains($"keywords={prerecordedTranscriptionOptions.Keywords[0].ToLower()}", result);

        }

        [Fact]
        public void GetParameters_Should_Return_String_When_Passing_Decimal_Parameter()
        {
            //Act
            // need to set manual as the precison can be very long and gets trimmed from autogenerated value
            prerecordedTranscriptionOptions.UtteranceSplit = (decimal)2.3;
            var result = QueryParameterUtil.GetParameters(prerecordedTranscriptionOptions);

            //Assert
            Assert.NotNull(result);
            Assert.Contains($"utt_split={prerecordedTranscriptionOptions.UtteranceSplit}", result);
        }

        [Fact]
        public void GetParameters_Should_Return_String_When_Passing_Boolean_Parameter()
        {
            //Arrange 
            var obj = new AutoFaker<PrerecordedTranscriptionOptions>().Generate();

            //Act
            var result = QueryParameterUtil.GetParameters(obj);

            //Assert
            Assert.NotNull(result);
            Assert.Contains($"{nameof(obj.Paragraphs).ToLower()}={obj.Paragraphs.ToString()?.ToLower()}", result);
        }

        [Fact]
        public void GetParameters_Should_Return_String_When_Passing_DateTime_Parameter()
        {
            //Arrange 
            var obj = new AutoFaker<ListAllRequestsOptions>().Generate();
            var date = obj.StartDateTime.Value.ToString("yyyy-MM-dd");

            //Act
            var result = QueryParameterUtil.GetParameters(obj);

            //Assert
            Assert.NotNull(result);
            Assert.Contains($"start={date}", result);
        }

        [Fact]
        public void GetParameters_Should_Return_Empty_String_When_Parameter_Has_No_Values()
        {
            //Arrange 
            var obj = new PrerecordedTranscriptionOptions();

            //Act
            var result = QueryParameterUtil.GetParameters(obj);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(string.Empty, result);
        }
    }
}